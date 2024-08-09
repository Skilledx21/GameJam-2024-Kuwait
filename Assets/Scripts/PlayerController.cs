using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public float coyoteTime = 0.2f; // Coyote time duration

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpsLeft;
    private float horizontalInput;
    private float coyoteTimeCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Check if grounded and set coyote time counter
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            jumpsLeft = maxJumps;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump logic with coyote time
        if (Input.GetButtonDown("Jump") && (isGrounded || coyoteTimeCounter > 0f || jumpsLeft > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            coyoteTimeCounter = 0f;
            jumpsLeft--;
        }

        // Handle movement
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}
