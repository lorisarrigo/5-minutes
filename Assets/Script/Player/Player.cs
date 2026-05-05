using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    InputMap inputs;
    Animator anim;
    Rigidbody2D rb;

    //Movement
    [SerializeField] float baseSpeed, sprintSpeed, currentSpeed; //speed variables
    [SerializeField] SpriteRenderer plSprite;
    //Jump
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce;
    [SerializeField] float radius; //range of the GroundCheck
    public bool IsGrounded = false;

    //health
    [SerializeField] float maxHealth;
    public float currentHealth;
    [SerializeField] float deathDuration; //hit + death animation
    public static event Action OnHit, OnGO;

    public static Player Instance;
    private void Awake()
    {
        if(Instance != null)
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
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Jump.started += JumpAction;
        inputs.Player.Sprint.started += Sprinting;
        inputs.Player.Sprint.canceled += EndSprinting;
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
        Vector2 move = inputs.Player.Movement.ReadValue<Vector2>();
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
        if (IsGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("IsJumping");
        }
    }
    #endregion
    #region Health System
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth > 0)
            anim.SetTrigger("IsHitted");
        OnHit?.Invoke();
    }

    public void Despawn()
    {
        StartCoroutine(DeathSequence());
    }
    #endregion
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
    private IEnumerator DeathSequence()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        currentSpeed = 0;

        anim.SetTrigger("IsDying");
        yield return new WaitForSeconds(deathDuration);
        OnGO?.Invoke();
    }
}
