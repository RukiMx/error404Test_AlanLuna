using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai.BehaviourTree
{
    public class Selector : Composite
    {
        public Selector() { }
        public Selector(List<Node> children) : base(children)
        {
        }

        public override State Evaluate()
        {
            foreach (var child in _children)
            {
                switch (child.Evaluate())
                {
                    case State.Success:
                        _state = State.Success;
                        return _state;
                    case State.Running:
                        _state = State.Running;
                        return _state;
                }
            }

            _state = State.Failure;
            return _state;
        }
    }
}