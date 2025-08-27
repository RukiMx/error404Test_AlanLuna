using UnityEngine;

[CreateAssetMenu(fileName = "NpcGuardData", menuName = "AI/EnemyData")]
public class NpcGuardData : ScriptableObject
{
    [Header("Detection")]
    public float detectionRange = 2f;
    public float attackRange = 2f;

    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    [Header("Attack")]
    public float attackCooldown = 1.5f;
}