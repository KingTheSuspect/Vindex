using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public int maxJumps = 2;
    private Animator animator;
    [HideInInspector]public bool safeJump;
    private SpriteRenderer sr;

    private int jumpsRemaining;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        safeJump = true;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Yatay hareket kontrolü
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (moveX > 0)
        {
            sr.flipX = false;
        }
        else if (moveX < 0)
        {
            sr.flipX = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Zýplama kontrolü
        if (Input.GetButtonDown("Jump") && (jumpsRemaining > 0) && safeJump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Yatay hýzý korumak için dikey hýzý sýfýrla
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpsRemaining--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Yerdeyken zýplama durumunu sýfýrla ve zýplama hakkýný yenile
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
