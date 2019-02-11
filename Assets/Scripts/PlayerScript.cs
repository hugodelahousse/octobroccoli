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

    [SerializeField]
    private bool isGrounded = true;
    
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = rb.IsTouchingLayers(groundLayer);
        if (isGrounded && Input.GetButtonDown(gravityButton))
            rb.gravityScale *= -1;

        float deltaX = (Camera.main.transform.position.x - transform.position.x)
        * speedElasticity;

        rb.velocity = new Vector2(playerVelocity.x + deltaX, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Consumable")) {
            ConsumableScript script = other.GetComponent<ConsumableScript>();
            score += script.value;
            script.consume();
        }
    }
}
