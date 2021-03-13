using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.5f, 10f)] private float movementSpeed = 5f;
    [SerializeField, Range(15f, 180f)] private float rotationSpeed = 60f;
    [SerializeField, Range(1f, 5f)] private float jumpForceValue = 2f;
    private Vector3 movementDirection;
    private Vector3 relativeMovementDirection;
    private Vector3 playerVelocity;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        var inputMovement = context.ReadValue<Vector2>();
        movementDirection = new Vector3(inputMovement.x, movementDirection.y, inputMovement.y);
        //relativeMovementDirection = transform.TransformDirection(movementDirection)
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started && characterController.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(-jumpForceValue * Physics.gravity.y);
        }
    }

    private void Move()
    {
        if(characterController.isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }

        if(movementDirection != Vector3.zero)
        {
            var relativeDirection = transform.TransformDirection(movementDirection);
            characterController.Move(relativeDirection * (movementSpeed * Time.deltaTime));
        }

        playerVelocity += Physics.gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void Rotate()
    {
        //var newRotation = Quaternion.LookRotation()
    }
}
