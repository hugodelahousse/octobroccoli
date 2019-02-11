using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private string gravityButton = "gravity_P1"; 

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Vector2 playerVelocity;

    [SerializeField]
    float speedElasticity = 1;

    public int score = 0;

    private Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        size = GetComponent<BoxCollider2D>().bounds.size;
    }

    void FixedUpdate()
    {
        float deltaX = (Camera.main.transform.position.x - transform.position.x)
        * speedElasticity;

        rb.velocity = new Vector2(playerVelocity.x + deltaX, rb.velocity.y);
    }

    void Update()
    {

        if (Input.GetButtonDown(gravityButton))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position - (size.x * Vector3.right / 2),
                (Vector2.down * rb.gravityScale).normalized, size.y / 2 + 0.1f,
                groundLayer
            );
            bool isGrounded = hit.collider != null;
            if (isGrounded)
                rb.gravityScale *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Consumable")) {
            ConsumableScript script = other.GetComponent<ConsumableScript>();
            score += script.value;
            script.consume();
        }
    }
}
