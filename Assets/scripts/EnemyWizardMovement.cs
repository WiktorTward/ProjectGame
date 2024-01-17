using UnityEngine;

public class EnemyWizardMovement : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za którą podążamy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promień detekcji postaci
    public float stopFollowRadius = 7.0f; // Dodatkowy promień, po przekroczeniu którego przeciwnik przestaje śledzić postać
    public float minDistance = 2.0f; // Minimalny dystans, na jaki przeciwnik utrzymuje od gracza
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isFollowing = false; // Flaga określająca, czy przeciwnik powinien podążać

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            // Sprawdzamy, czy postać jest w zasięgu
            if (distanceToTarget <= detectionRadius)
            {
                isFollowing = true; // Włączamy tryb śledzenia
            }

            // Jeśli przeciwnik jest w trybie śledzenia
            if (isFollowing)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Obliczamy dystans do postaci
                float distanceToPlayer = Vector3.Distance(transform.position, targetCharacter.position);

                // Jeśli dystans do postaci jest większy niż minimalny dystans
                if (distanceToPlayer > minDistance)
                {
                    // Zmniejszamy dystans do postaci do minimalnego dystansu
                    rb.MovePosition(rb.position + (Vector2)moveDirection * (distanceToPlayer - minDistance) * moveSpeed * Time.deltaTime);
                }
            }
        }

        Vector2 enemyMovement = GetEnemyMovementVector();

        animator.SetFloat("Horizontal", enemyMovement.x);
        animator.SetFloat("Vertical", enemyMovement.y);
        animator.SetFloat("speed", enemyMovement.sqrMagnitude);

        if (enemyMovement != Vector2.zero)
        {
            // Ustawiamy flipX w zależności od kierunku ruchu
            rbSprite.flipX = enemyMovement.x < 0;
        }
    }

    Vector2 GetEnemyMovementVector()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            // Sprawdzamy, czy postać jest w zasięgu
            if (distanceToTarget <= detectionRadius)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Zwracamy wektor ruchu przeciwnika
                return new Vector2(moveDirection.x, moveDirection.y);
            }
            else if (isFollowing && distanceToTarget <= stopFollowRadius)
            {
                // Jeśli przeciwnik przekroczył pierwotny zasięg, ale jest w nowym zasięgu, nadal śledź postać
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                return new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        // Jeśli przeciwnik nie porusza się, zwracamy wektor zerowy
        return Vector2.zero;
    }
}


