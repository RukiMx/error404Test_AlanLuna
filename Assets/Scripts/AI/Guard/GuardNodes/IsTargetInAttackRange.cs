using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ai.BehaviourTree;

public class IsTargetInAttackRange : Condition
{
    private Transform npc;
    private Transform target;
    private float attackRange;

    public IsTargetInAttackRange(Transform npc, Transform target, float attackRange) {
        this.npc = npc;
        this.target = target;
        this.attackRange = attackRange;
    }

    protected override bool CheckCondition()
    {
        return Vector3.Distance(npc.position, target.position) <= attackRange;
    }
}
