using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour, IDamageable
{
    InputMap inputs;
    Animator anim;
    Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] SpriteRenderer plSprite;
    [SerializeField] float baseSpeed, sprintSpeed;
    Vector2 move; //used in the SFX coroutines
    float currentSpeed; //speed variables

    [Header("Jump")]
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce;
    [SerializeField] float radius; //range of the GroundCheck
    public bool IsGrounded = false;

    [Header("Health")]
    [SerializeField] float maxHealth;
    [HideInInspector] public float currentHealth;
    [SerializeField] float deathDuration; //death animation
    public static event Action OnHit, OnGO;

    [Header("Sound")]
    [SerializeField] AudioClip walkingStepSfx;
    [SerializeField] AudioClip runningStepSfx;
    [SerializeField] float walkingSfxCooldown, runningSfxCooldown;
    [SerializeField] AudioClip jumpSfx;
    [SerializeField] AudioClip runJumpSfx;
    [SerializeField] AudioClip landSfx;
    [SerializeField] float landIdleSfxCooldown, landWalkSfxCooldown, landRunSfxCooldown;
    [SerializeField] AudioClip hitSfx;

    public static Player Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        inputs = new InputMap();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentSpeed = baseSpeed;
        StartCoroutine(Walking());
        StartCoroutine(Running());
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Sprint.started += Sprinting;
        inputs.Player.Sprint.canceled += EndSprinting;
        inputs.Player.Jump.started += JumpAction;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Jump.started -= JumpAction;
        inputs.Player.Sprint.started -= Sprinting;
        inputs.Player.Sprint.canceled -= EndSprinting;
    }
    #region movement
    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        move = inputs.Player.Movement.ReadValue<Vector2>();
        if (move != Vector2.zero)
        {
            //player flipping
            if (move.x < 0)
                plSprite.flipX = true;
            else if (move.x > 0)
                plSprite.flipX = false;

            //player movement
            Vector2 position = rb.position + Time.fixedDeltaTime * currentSpeed * move;
            rb.position = position;
            if (IsGrounded)
                anim.SetBool("IsWalking", true);
        }
        else if (move == Vector2.zero)
            anim.SetBool("IsWalking", false);
    }
    void Sprinting(InputAction.CallbackContext context)
    {
        currentSpeed = sprintSpeed;
        if (IsGrounded)
            anim.SetBool("IsRunning", true);
    }
    void EndSprinting(InputAction.CallbackContext context)
    {
        currentSpeed = baseSpeed;
        anim.SetBool("IsRunning", false);
    }
    void JumpAction(InputAction.CallbackContext context)
    {
        if (Time.timeScale != 0 && IsGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("IsJumping");
            StartCoroutine(Jump());
        }
    }
    
    #endregion
    #region Health System
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        SFXManager.instance.PlaySfx(hitSfx);
        if (currentHealth > 0)
            anim.SetTrigger("IsHitted");
        OnHit?.Invoke();
    }

    public void Despawn()
    {
        StartCoroutine(DeathSequence());
    }
    private IEnumerator DeathSequence()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        currentSpeed = 0;

        anim.SetTrigger("IsDying");
        yield return new WaitForSeconds(deathDuration);
        OnGO?.Invoke();
    }
    #endregion
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    #region walking coroutines
    IEnumerator Walking()
    {
        while (true)
        {
            if (IsGrounded && move.magnitude > 0.1f && !inputs.Player.Sprint.IsPressed())
                SFXManager.instance.PlaySfx(walkingStepSfx);
            yield return new WaitForSeconds(walkingSfxCooldown);
        }
    }
    IEnumerator Running()
    {
        while (true)
        {
            if (IsGrounded && move.magnitude > 0.1f && inputs.Player.Sprint.IsPressed())
                SFXManager.instance.PlaySfx(runningStepSfx);
            yield return new WaitForSeconds(runningSfxCooldown);
        }
    }
    IEnumerator Jump()
    {
        if (move.magnitude < 0.1f)
        {
            SFXManager.instance.PlaySfx(jumpSfx);
            yield return new WaitForSeconds(landIdleSfxCooldown);
            SFXManager.instance.PlaySfx(landSfx);
        }
        else if (move.magnitude > 0.1f && !inputs.Player.Sprint.IsPressed())
        {
            SFXManager.instance.PlaySfx(jumpSfx);
            yield return new WaitForSeconds(landWalkSfxCooldown);
            SFXManager.instance.PlaySfx(landSfx);
        }
        else if (move.magnitude > 0.1f && inputs.Player.Sprint.IsPressed())
        {
            SFXManager.instance.PlaySfx(runJumpSfx);
            yield return new WaitForSeconds(landRunSfxCooldown);
            SFXManager.instance.PlaySfx(landSfx);
        }
    }
    #endregion
}