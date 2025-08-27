using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ai.BehaviourTree;

public class IsTargetInDetectionRange : Condition
{
    private Transform npc;
    private Transform target;
    private float detectionRange;

    public IsTargetInDetectionRange(Transform npc, Transform target, float detectionRange)
    {
        this.npc = npc;
        this.target = target;
        this.detectionRange = detectionRange;
    }
    
    protected override bool CheckCondition()
    {
        return Vector3.Distance(npc.position, target.position) <= detectionRange;
    }
}

