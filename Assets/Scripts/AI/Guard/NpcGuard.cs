using System;
using Ai.BehaviourTree;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NpcGuard : MonoBehaviour
{
    [Header("Movement Data")]
    [SerializeField] private NpcGuardData _guardData;
    
    [Header("Patrolling")]
    [SerializeField] private Transform[] patrolPoints;
    
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _target;
    
    private Node _root;

    #region Unity Methods
    private void OnEnable()
    {
        PlayerLocator.OnPlayerSpawned += OnPlayerSpawned;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _target = PlayerLocator.PlayerInstance.transform;

        // Build behaviour tree
        var engageSequence = new Sequence();
        engageSequence.AddChild(new IsTargetInDetectionRange(transform, _target, _guardData.detectionRange));
        // Only engage if the target is in detection range.

        var attackSequence = new Sequence();
        attackSequence.AddChild(new IsTargetInAttackRange(transform, _target, _guardData.attackRange));
        attackSequence.AddChild(new AttackAction(_animator, _guardData.attackCooldown));
        // If the target is in attack range, then attack.

        var chaseSequence = new Sequence();
        chaseSequence.AddChild(new IsTargetInDetectionRange(transform, _target, _guardData.detectionRange));
        chaseSequence.AddChild(new ChaseAction(_agent, _target, _guardData.chaseSpeed));
        // If the target is his detection range, chase.
        
        var engageSelector = new Selector();
        engageSelector.AddChild(attackSequence);
        engageSelector.AddChild(chaseSequence);
        // Try to attack first. If that fails then try to chase.
        
        engageSequence.AddChild(engageSelector);
        // If the target is in detection range then either attack (if possible) or chase.
        
        var patrol = new PatrolAction(_agent, patrolPoints, _guardData.patrolSpeed);
        // If no target is detected, back to patrolling.

        var rootSelector = new Selector();
        rootSelector.AddChild(engageSequence);
        rootSelector.AddChild(patrol);

        _root = rootSelector;
    }

    private void Update()
    {
        _root.Evaluate();
    }
    
    private void OnDisable()
    {
        PlayerLocator.OnPlayerSpawned -= OnPlayerSpawned;
    }
    #endregion
    
    #region Private Methods
    private void OnPlayerSpawned(Transform player)
    {
        _target = player;
    }
    #endregion
}
   