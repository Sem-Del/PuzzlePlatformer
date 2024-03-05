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
    private Dialog Trigger;
    public PlayableDirector powerIndicatorVisible;

    private bool isGrounded;
    public bool powerSystemUnlocked = false;
    
    public GameObject powerSystem;
    private BoxCollider2D powerMachineCollider;
    private SpriteRenderer powerMachineRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Trigger = FindObjectOfType<Dialog>();
        powerMachineCollider = powerSystem.GetComponent<BoxCollider2D>();
        powerMachineRenderer = powerSystem.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (DialogueManger.isActive)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

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
                powerMachineCollider.enabled = false;
                powerMachineRenderer.enabled = false;
                powerIndicatorVisible.Play();
                Dialog dialogScript = other.gameObject.GetComponent<Dialog>();
            if (dialogScript != null)
            {
                dialogScript.startDialogue(); 
            }
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
