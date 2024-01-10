using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator anim;
    private SpriteRenderer rbSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rbSprite.flipX = true;
        }
        else
        {
             rbSprite.flipX = false;
        }

        anim.SetFloat("Horizontal", movementDirection.x);
        anim.SetFloat("Vertical", movementDirection.y);
        anim.SetFloat("Speed", movementDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }
}