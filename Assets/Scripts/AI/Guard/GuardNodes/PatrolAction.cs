using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai.BehaviourTree
{
    public class PatrolAction : Action
    {
        private NavMeshAgent _agent;
        private Transform[] _waypoints;
        private int _currentIndex = 0;
        private float _speed;

        public PatrolAction(NavMeshAgent agent, Transform[] waypoints, float speed)
        {
            _agent = agent;
            _waypoints = waypoints;
            _speed = speed;
        }

        public override State Evaluate()
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                if (_agent.speed != _speed)
                {
                    _agent.speed = _speed;
                }
                _currentIndex = (_currentIndex + 1) % _waypoints.Length;
                _agent.SetDestination(_waypoints[_currentIndex].position);
            }
            return State.Running;
        }
    }

}
