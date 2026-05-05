using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    InputMap inputs;

    Rigidbody2D rb;

    //Movement
    [SerializeField] float baseSpeed, sprintSpeed, currentSpeed; //speed variables

    //Jump
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce;
    [SerializeField] float radius; //range of the GroundCheck
    bool IsGrounded = false;

    //health
    [SerializeField] float maxHealth;
    public float currentHealth;
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
        inputs = new InputMap();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Jump.started += JumpAction;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Jump.started -= JumpAction;
    }
    #region movement
    private void FixedUpdate()
    {
        Vector2 move = inputs.Player.Movement.ReadValue<Vector2>();
        if (inputs.Player.Sprint.IsPressed())
            currentSpeed = sprintSpeed;
        else
            currentSpeed = baseSpeed;
        if (move != Vector2.zero)
        {
            Vector2 position = rb.position + Time.fixedDeltaTime * currentSpeed * move;
            rb.position = position;
        }

        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
    }
    void JumpAction(InputAction.CallbackContext context)
    {
        if (IsGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    #endregion
    #region Health System
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        OnHit?.Invoke();
    }

    public void Despawn()
    {
        OnGO?.Invoke();
    }
    #endregion
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

}
