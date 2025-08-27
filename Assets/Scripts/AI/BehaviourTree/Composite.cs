using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai.BehaviourTree
{
    public abstract class Composite : Node
    {
        protected List<Node> _children = new List<Node>();
        public void AddChild(Node node) => _children.Add(node);

        
        public Composite() { }
        
        public Composite(List<Node> children)
        {
            _children = children;
        }
    }
}
