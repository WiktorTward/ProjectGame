using UnityEngine;

public class EnemyWolfMovement : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za któr¹ pod¹¿amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promieñ detekcji postaci
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    Vector2 movement;


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

            // Sprawdzamy, czy postaæ jest w zasiêgu
            if (distanceToTarget <= detectionRadius)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Zwracamy wektor ruchu przeciwnika
                return new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        // Jeœli przeciwnik nie porusza siê, zwracamy wektor zerowy
        return Vector2.zero;
    }

    void Update()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            // Sprawdzamy, czy postaæ jest w zasiêgu
            if (distanceToTarget <= detectionRadius)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Ruch w kierunku postaci
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }

        Vector2 enemyMovement = GetEnemyMovementVector();

        animator.SetFloat("Horizontal", enemyMovement.x);
        animator.SetFloat("Vertical", enemyMovement.y);
        animator.SetFloat("speed", enemyMovement.sqrMagnitude);

        if (enemyMovement != Vector2.zero)
        {
            // Ustawiamy flipX w zale¿noœci od kierunku ruchu
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
}
