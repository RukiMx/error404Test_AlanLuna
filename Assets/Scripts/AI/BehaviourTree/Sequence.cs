using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai.BehaviourTree
{
    public class Sequence : Composite
    {
        public Sequence() { }
        public Sequence(List<Node> children) : base(children)
        {
        }

        public override State Evaluate()
        {
            bool runningChild = false;
            foreach (var child in _children)
            {
                switch (child.Evaluate())
                {
                    case State.Failure:
                        _state = State.Failure;
                        return _state;
                    case State.Running:
                        runningChild = true;
                        break;
                }
            }

            _state = runningChild ? State.Running : State.Success;
            return _state;
        }
    }
}
