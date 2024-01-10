using UnityEngine;

public class TestKamilWizardMovement : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za kt�r� pod��amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promie� detekcji postaci
    public float stopFollowRadius = 7.0f; // Dodatkowy promie�, po przekroczeniu kt�rego przeciwnik przestaje �ledzi� posta�
    public float minDistance = 2.0f; // Minimalny dystans, na jaki przeciwnik utrzymuje od gracza
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isFollowing = false; // Flaga okre�laj�ca, czy przeciwnik powinien pod��a�

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

            // Sprawdzamy, czy posta� jest w zasi�gu
            if (distanceToTarget <= detectionRadius)
            {
                isFollowing = true; // W��czamy tryb �ledzenia
            }

            // Je�li przeciwnik jest w trybie �ledzenia
            if (isFollowing)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Obliczamy dystans do postaci
                float distanceToPlayer = Vector3.Distance(transform.position, targetCharacter.position);

                // Je�li dystans do postaci jest wi�kszy ni� minimalny dystans
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
            // Ustawiamy flipX w zale�no�ci od kierunku ruchu
            rbSprite.flipX = enemyMovement.x < 0;
        }
    }

    Vector2 GetEnemyMovementVector()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            // Sprawdzamy, czy posta� jest w zasi�gu
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
                // Je�li przeciwnik przekroczy� pierwotny zasi�g, ale jest w nowym zasi�gu, nadal �led� posta�
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                return new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        // Je�li przeciwnik nie porusza si�, zwracamy wektor zerowy
        return Vector2.zero;
    }
}
