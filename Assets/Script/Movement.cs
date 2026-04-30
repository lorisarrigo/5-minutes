using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    InputMap inputs;

    Rigidbody2D rb;

    //Movement
    [SerializeField] float baseSpeed, sprintSpeed, currentSpeed;

    //Jump
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] float radius;
    [SerializeField] float jumpForce;
    bool IsGrounded = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = new InputMap();
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
