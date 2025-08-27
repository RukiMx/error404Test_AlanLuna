using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai.BehaviourTree
{
    public abstract class Condition : Node
    {
        protected abstract bool CheckCondition();

        public override State Evaluate()
        {
            return CheckCondition() ? State.Success : State.Failure;
        }
    }
}
