using System.Collections.Generic;
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

    [Header("Audio")]
    [SerializeField] private LocomotionSoundsData locomotionSounds;
    [SerializeField] private List<AudioClip> attackSounds;
    [SerializeField] private List<AudioClip> hurtSounds;
    [SerializeField] private AudioClip dieSound;

    [HideInInspector] public bool inAttack;
    private bool isDead;

    private Vector2 inputDirection;
    private Vector3 playerVelocity;

    // References
    [Header("References")]
    [SerializeField] private AudioSource audioSource;
    public MeleeWeapon meleeWeapon;
    private CharacterController characterController;
    private Animator animator;

    // Animation hashes
    private int hashMoveSpeed = Animator.StringToHash("MoveSpeed");
    private int hashIsGrounded = Animator.StringToHash("IsGrounded");
    private int hashJump = Animator.StringToHash("Jump");
    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack");
    private int hashHurt = Animator.StringToHash("Hurt");
    private int hashDie = Animator.StringToHash("Die");

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        meleeWeapon.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(isDead) return;

        Move();
        animator.SetBool(hashIsGrounded, characterController.isGrounded);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(inAttack)
        {
            inputDirection = Vector2.zero;
            return;
        }
        inputDirection = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started && characterController.isGrounded && !inAttack)
        {
            playerVelocity.y += Mathf.Sqrt(-jumpForceValue * Physics.gravity.y);
            animator.SetTrigger(hashJump);

            var randomSoundId = Random.Range(0, locomotionSounds.jumpSounds.Count);
            audioSource.PlayOneShot(locomotionSounds.jumpSounds[randomSoundId]);
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if(context.started && !inAttack)
        {
            animator.SetTrigger(hashMeleeAttack);
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

    public void MeleeAttack()
    {
        var randomSoundId = Random.Range(0, attackSounds.Count);
        audioSource.PlayOneShot(attackSounds[randomSoundId]);

        meleeWeapon.MakeAttack();
    }

    public void GetHit()
    {
        var randomSoundId = Random.Range(0, hurtSounds.Count);
        audioSource.PlayOneShot(hurtSounds[randomSoundId]);

        animator.SetTrigger(hashHurt);
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger(hashDie);
        audioSource.PlayOneShot(dieSound);
    }

    public void Stepped()
    {
        var randomSoundId = Random.Range(0, locomotionSounds.walkFootstepSounds.Count);
        audioSource.PlayOneShot(locomotionSounds.walkFootstepSounds[randomSoundId]);
    }

    public void Landed()
    {
        audioSource.PlayOneShot(locomotionSounds.land);
    }
}
