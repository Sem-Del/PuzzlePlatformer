using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Vector2 boxSize;
    public float castDistance;
    public string groundTag;
    public string movePowerTag;

    private Rigidbody2D rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Movement
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(groundTag) || collider.CompareTag(movePowerTag))
            {
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
