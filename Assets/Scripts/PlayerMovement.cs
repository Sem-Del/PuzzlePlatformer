using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Vector2 boxSize;
    public float castDistance;
    public string groundTag;
    public string movePowerTag;
    public string buttonTag;
    
    private Rigidbody2D rb;
    private TimelineController Animation;

    private bool isGrounded;
    private bool powerSystemUnlocked = false;

    public GameObject powerSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerItem"))
        {
            if (other.gameObject == powerSystem)
            {
                Destroy(other.gameObject);
                powerSystemUnlocked = true;
            }
        }
    }

    public bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(groundTag) || collider.CompareTag(movePowerTag) || collider.CompareTag(buttonTag))
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
