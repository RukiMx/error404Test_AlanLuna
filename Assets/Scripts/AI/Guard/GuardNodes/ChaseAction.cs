using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai.BehaviourTree
{
    public class ChaseAction : Action
    {
        private NavMeshAgent _agent;
        private Transform _target;
        private float _speed;

        public ChaseAction(NavMeshAgent agent, Transform target, float speed)
        {
            _agent = agent;
            _target = target;
            _speed = speed;
        }

        public override State Evaluate()
        {
            if (_agent.speed != _speed)
            {
                _agent.speed = _speed;
            }
            _agent.SetDestination(_target.position);
            return State.Running;
        }
    }

}
