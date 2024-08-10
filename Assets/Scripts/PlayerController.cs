using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Animator pAnimator;

    bool isFlipped;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0 && !isFlipped)
        {
            playerFlip();
            //pAnimator.Play("PlayerMove");
        }
        else if (horizontalInput < 0 && isFlipped)
        {
            playerFlip();
            //pAnimator.Play("PlayerMove");
        }
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
            pAnimator.Play("PlayerJump");
        }

        // Handle movement
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.Instance.canTravel)
            {
                if (GameManager.Instance.challengeNum == 1)
                {
                    SceneManager.LoadScene("MiniGameQuestionAnswer");
                }else if (GameManager.Instance.challengeNum == 2)
                {
                    SceneManager.LoadScene("MinigameFishing");
                }
                else if (GameManager.Instance.challengeNum == 3)
                {
                    SceneManager.LoadScene("MiniGameDeepDive");
                }
            }
        }
    }

    public void playerFlip()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
        isFlipped = !isFlipped;
    }
}
