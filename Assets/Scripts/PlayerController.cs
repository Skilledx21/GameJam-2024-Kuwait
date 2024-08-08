using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public variables for configuring movement and jumping
    public float moveSpeed = 10f; // Speed of horizontal movement
    public float maxSpeed = 5f;   // Maximum horizontal speed
    public float jumpForce = 15f; // Initial force applied when jumping
    public float coyoteTime = 0.2f; // Time allowed to jump after leaving the ground
    public float jumpBufferTime = 0.2f; // Time allowed to buffer a jump input before landing

    // Private variables for internal use
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private float moveInput; // Horizontal movement input
    private float coyoteTimeCounter; // Counter for coyote time
    private float jumpBufferCounter; // Counter for jump buffer time
    private bool isJumping; // Flag to check if the player is currently jumping
    private float jumpTimeCounter; // Counter for variable jump height
    public float maxJumpTime = 0.35f; // Maximum time the player can hold the jump button

    // Variables for ground check
    public Transform groundCheck; // Position for ground check
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle
    public LayerMask groundLayer; // Layer mask to specify what is considered ground

    private bool isGrounded; // Flag to check if the player is on the ground

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Ground check using Physics2D.OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle jump input
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime; // Reset jump buffer counter
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime; // Decrease jump buffer counter over time
        }

        // Handle jumping logic with coyote time and jump buffer
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
            isJumping = true; // Set jumping flag
            jumpTimeCounter = maxJumpTime; // Reset jump time counter
            jumpBufferCounter = 0f; // Reset jump buffer counter
        }

        // Handle variable jump height
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Continue applying jump force
                jumpTimeCounter -= Time.deltaTime; // Decrease jump time counter
            }
            else
            {
                isJumping = false; // Stop jumping when max jump time is reached
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false; // Stop jumping when jump button is released
        }
    }

    void FixedUpdate()
    {
        // Smooth horizontal movement with acceleration and deceleration
        float targetSpeed = moveInput * maxSpeed; // Target speed based on input
        float speedDifference = targetSpeed - rb.velocity.x; // Difference between target speed and current speed
        float accelerationRate = (isGrounded ? moveSpeed : moveSpeed * 0.5f); // Apply different acceleration rates based on grounded state
        float movement = speedDifference * accelerationRate * Time.fixedDeltaTime; // Calculate movement force

        rb.AddForce(new Vector2(movement, 0), ForceMode2D.Impulse); // Apply movement force

        // Instantly stop horizontal movement if no input is given
        if (Mathf.Abs(moveInput) < 0.01f && isGrounded)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Limit the horizontal speed to the maximum speed
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);

        // Update coyote time counter
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime; // Reset coyote time counter when on the ground
        }
        else
        {
            coyoteTimeCounter -= Time.fixedDeltaTime; // Decrease coyote time counter over time
        }
    }

    // Draw a wireframe sphere in the Scene view to visualize the ground check position and radius
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
