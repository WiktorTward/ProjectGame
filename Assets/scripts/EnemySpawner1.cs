using UnityEngine;

public class TestKamilWizardMovement : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za któr¹ pod¹¿amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promieñ detekcji postaci
    public float stopFollowRadius = 7.0f; // Dodatkowy promieñ, po przekroczeniu którego przeciwnik przestaje œledziæ postaæ
    public float minDistance = 2.0f; // Minimalny dystans, na jaki przeciwnik utrzymuje od gracza
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isFollowing = false; // Flaga okreœlaj¹ca, czy przeciwnik powinien pod¹¿aæ

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

            // Sprawdzamy, czy postaæ jest w zasiêgu
            if (distanceToTarget <= detectionRadius)
            {
                isFollowing = true; // W³¹czamy tryb œledzenia
            }

            // Jeœli przeciwnik jest w trybie œledzenia
            if (isFollowing)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Obliczamy dystans do postaci
                float distanceToPlayer = Vector3.Distance(transform.position, targetCharacter.position);

                // Jeœli dystans do postaci jest wiêkszy ni¿ minimalny dystans
                if (distanceToPlayer > minDistance)
                {
                    // Zmniejszamy dystans do postaci do minimalnego dystansu
                    transform.position += moveDirection * (distanceToPlayer - minDistance) * moveSpeed * Time.deltaTime;
                }
            }
        }

        Vector2 enemyMovement = GetEnemyMovementVector();

        animator.SetFloat("Horizontal", enemyMovement.x);
        animator.SetFloat("Vertical", enemyMovement.y);
        animator.SetFloat("speed", enemyMovement.sqrMagnitude);

        if (enemyMovement != Vector2.zero)
        {
            // Ustawiamy flipX w zale¿noœci od kierunku ruchu
            rbSprite.flipX = enemyMovement.x < 0;
        }
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
            else if (isFollowing && distanceToTarget <= stopFollowRadius)
            {
                // Jeœli przeciwnik przekroczy³ pierwotny zasiêg, ale jest w nowym zasiêgu, nadal œledŸ postaæ
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                return new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        // Jeœli przeciwnik nie porusza siê, zwracamy wektor zerowy
        return Vector2.zero;
    }
}
