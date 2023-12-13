using UnityEngine;

public class EnemyWolfMovement : MonoBehaviour
{
    public Transform targetCharacter;
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f;
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isCollidingWithPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    Vector2 GetEnemyMovementVector()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            if (distanceToTarget <= detectionRadius)
            {
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                return new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        return Vector2.zero;
    }

    void Update()
    {
        if (!isCollidingWithPlayer && targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            if (distanceToTarget <= detectionRadius)
            {
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Ustawianie prêdkoœci, zamiast bezpoœrednio manipulowaæ transform.position
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            }
            else
            {
                // Zatrzymaj przeciwnika, gdy postaæ jest poza zasiêgiem
                rb.velocity = Vector2.zero;
            }
        }

        Vector2 enemyMovement = GetEnemyMovementVector();

        animator.SetFloat("Horizontal", enemyMovement.x);
        animator.SetFloat("Vertical", enemyMovement.y);
        animator.SetFloat("speed", enemyMovement.sqrMagnitude);

        if (enemyMovement != Vector2.zero)
        {
            if (enemyMovement.x < 0)
            {
                rbSprite.flipX = true;
            }
            else
            {
                rbSprite.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }
}