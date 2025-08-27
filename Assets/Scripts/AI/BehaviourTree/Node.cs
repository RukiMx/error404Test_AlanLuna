namespace Ai.BehaviourTree
{
    public abstract class Node
    {
        public enum State
        {
            Running,
            Success,
            Failure
        }
        protected State _state;
    
        public State CurrentState => _state;
    
        public abstract State Evaluate();
    }
}