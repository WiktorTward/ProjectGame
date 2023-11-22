using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float MaxSpeed = 10f;
    [SerializeField] private float stopForce = 10f;
    private Rigidbody rb;
    private Vector3 movementDirection;
    private Animator anim;
    private SpriteRenderer rbSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

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

        if (rb.velocity.magnitude < MaxSpeed)
        {
            rb.AddForce(movementDirection * movementSpeed);
        }
    }
}