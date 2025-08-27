using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai.BehaviourTree
{
    public abstract class Action : Node
    {
        // We force each Action to implement its own logic :)
        public abstract override State Evaluate();
    }
}
