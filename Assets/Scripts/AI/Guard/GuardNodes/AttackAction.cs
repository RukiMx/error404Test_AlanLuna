using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai.BehaviourTree
{
    public class AttackAction : Action
    {
        private Animator _animator;
        private float _cooldown;
        private float _lastAttackTime;
        
        public AttackAction(Animator animator, float cooldown)
        {
            this._animator = animator;
            this._cooldown = cooldown;
        }

        public override State Evaluate()
        {
            if (Time.time > _lastAttackTime + _cooldown)
            {
                Debug.Log("Attack!!!!");
                _lastAttackTime = Time.time;
                
                // TO DO: Trigger Animation
                //_animator.SetTrigger("Attack");
            }
            
            return State.Success;
        }
    }

}
