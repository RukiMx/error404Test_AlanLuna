using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData _plData;
    
    [Header("State")]
    public bool isRunning;
    
    CharacterController _characterController;
    PlayerInputActions _input;
    Vector2 _move;
    float _velocityY;
    float _turnSmoothVelocity;

#region Unity Methods
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInputActions();
    }

    void OnEnable()
    {
        _input.Enable();
        Bind();
    }
    
    void Update()
    {
        float speed = isRunning ? _plData.runSpeed : _plData.walkSpeed;
        // Read input
        Vector3 inputDir = new Vector3(_move.x, 0f, _move.y);
        if (inputDir.sqrMagnitude < 0.01f) return;

        // Get camera yaw only
        float cameraYaw = Camera.main.transform.eulerAngles.y;
        Quaternion camRotation = Quaternion.Euler(0f, cameraYaw, 0f);

        // Rotate input relative to camera yaw
        Vector3 worldMove = camRotation * inputDir;


        _velocityY += _plData.gravity * Time.deltaTime;
        Vector3 velocity = worldMove.normalized * speed + Vector3.up * _velocityY;
        
        _characterController.Move(velocity * Time.deltaTime);
        
        if (_characterController.isGrounded) _velocityY = -2f;

        float targetYaw = Mathf.Atan2(_move.x, _move.y) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.Euler(0f, targetYaw, 0f);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _plData.rotationSpeed * Time.deltaTime);

    }
    
    void OnDisable()
    {
        _input.Disable();
    }
#endregion

#region Private Methods
    void Bind()
    {
        _input.Player.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
        _input.Player.Move.canceled += _ => _move = Vector2.zero;
        _input.Player.Run.performed += _ => isRunning = true;
        _input.Player.Run.canceled += _ => isRunning = false;
    }
#endregion
}