using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.5f, 10f)] private float maxForwardSpeed = 5f;
    [SerializeField, Range(0.5f, 10f)] private float maxBackwardSpeed = 2f;
    [SerializeField, Range(10f, 180f)] private float rotationSpeed = 60f;
    [SerializeField, Range(1f, 20f)] private float jumpForceValue = 2f;
    [SerializeField] private float groundAcceleration = 20f;
    [SerializeField] private float groundDeceleration = 25f;

    private Vector2 inputDirection;
    private Vector3 playerVelocity;

    // References
    private CharacterController characterController;
    private Animator animator;

    // Animation hashes
    private int hashMoveSpeed = Animator.StringToHash("MoveSpeed");
    private int hashIsGrounded = Animator.StringToHash("IsGrounded");
    private int hashJump = Animator.StringToHash("Jump");

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        animator.SetBool(hashIsGrounded, characterController.isGrounded);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started && characterController.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(-jumpForceValue * Physics.gravity.y);
            animator.SetTrigger(hashJump);
        }
    }

    private void Move()
    {
        // Check if on ground and reset velocity on Y axis.
        if(characterController.isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }

        // Apply gravity
        playerVelocity += Physics.gravity * Time.deltaTime;

        // Calculate desired velocity based on forward/back input movement.
        float desiredVelocityZ = inputDirection.y == 1f ? maxForwardSpeed : maxBackwardSpeed;
        // Multiply by direction
        desiredVelocityZ *= inputDirection.y;

        // Calculate acceleration (if player is pressing the movement button).
        float acceleration = inputDirection.y != 0f ? groundAcceleration : groundDeceleration;
        playerVelocity.z = Mathf.MoveTowards(playerVelocity.z, desiredVelocityZ, acceleration * Time.deltaTime);

        // Check if there is rotation in place and apply slight forward movement.
        if(inputDirection.y == 0f && inputDirection.x != 0f && playerVelocity.z < 1.5f)
        {
            playerVelocity.z = 1.5f;
        }

        characterController.Move(transform.TransformDirection(playerVelocity) * Time.deltaTime);
        transform.Rotate(Vector3.up * inputDirection.x * rotationSpeed * Time.deltaTime);
        animator.SetFloat(hashMoveSpeed, playerVelocity.z);        
    }
}
