using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    private Rigidbody2D rb;


    public int playerIndex = 1;
    private string gravityButton = "gravity_P"; 

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Vector2 playerVelocity;

    [SerializeField]
    float speedElasticity = 1;

    public int score = 0;

    private Vector3 size;

    private Collider2D col;

    [SerializeField]
    private LayerMask playerLayer;    

    private SpriteRenderer rend;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rend.flipY = rb.gravityScale < 0; 
        size = col.bounds.size;
        gravityButton += playerIndex;
    }

    void FixedUpdate()
    {
        float deltaX = (Camera.main.transform.position.x - transform.position.x)
        * speedElasticity;

        rb.velocity = new Vector2(playerVelocity.x + deltaX, rb.velocity.y);
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position - (size.x * Vector3.right / 2),
            (Vector2.down * rb.gravityScale).normalized, size.y / 2 + 0.1f,
            groundLayer
        );
        bool isGrounded = hit.collider != null;

        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetButtonDown(gravityButton))
        {
            if (!isGrounded)
                isGrounded = col.IsTouchingLayers(playerLayer);
            

            if (isGrounded)
            {
                rb.gravityScale *= -1;
                rend.flipY = rb.gravityScale < 0; 
            }
        }
        this.score = (int) (this.transform.position.x / 10);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Consumable")) {
            ConsumableScript script = other.GetComponent<ConsumableScript>();
            score += script.value;
            script.consume();
        }
    }
}
