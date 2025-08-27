using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigData", menuName = "PlayerConfigData")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float walkSpeed = 2.2f;
    public float runSpeed = 4.4f;
    public float gravity = -20f;
    public float turnSmoothTime = 0.06f;
    public float rotationSpeed = 10f;
    
    
}