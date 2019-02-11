using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isGrounded = true;
    
    private Rigidbody2D rb;
    private string gravityButton = "gravity_P1"; 

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Vector2 playerVelocity;

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

        Debug.Log(playerVelocity);
        rb.velocity = new Vector2(playerVelocity.x, rb.velocity.y);
        Debug.Log(rb.velocity);
    }

    void Update()
    {

    }
}
