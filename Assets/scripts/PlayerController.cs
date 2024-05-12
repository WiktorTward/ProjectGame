using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; // Movement speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movementDirection; // Direction of movement input
    private Animator anim; // Reference to the Animator component
    private SpriteRenderer rbSprite; // Reference to the SpriteRenderer component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        anim = GetComponent<Animator>(); // Get the Animator component
        rbSprite = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    void Update()
    {
        // Get movement input from horizontal and vertical axes
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        // Stop the player if horizontal or vertical input is released
        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.velocity = Vector3.zero;
        }

        // Flip player sprite horizontally based on horizontal input
        if (Input.GetAxis("Horizontal") < 0)
        {
            rbSprite.flipX = true;
        }
        else
        {
            rbSprite.flipX = false;
        }

        // Update Animator parameters based on movement direction and speed
        anim.SetFloat("Horizontal", movementDirection.x);
        anim.SetFloat("Vertical", movementDirection.y);
        anim.SetFloat("Speed", movementDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Move the player based on movement input and speed
        rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
