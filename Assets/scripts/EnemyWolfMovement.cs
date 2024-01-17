using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform target;  // Cel, za którym postaæ pod¹¿a
    public float moveSpeed = 5f;  // Szybkoœæ poruszania siê postaci
    public float rotationSpeed = 200f;  // Szybkoœæ obracania postaci
    public float detectionRadius = 5f;  // Zasiêg wykrywania celu
    public LayerMask obstacleLayer;  // Warstwa przeszkód
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FindPath();
        // Animacje
        UpdateAnimations();
    }

    void FindPath()
    {
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, detectionRadius, obstacleLayer);

        if (obstacles.Length > 0)
        {
            // Unikaj przeszkód
            Vector2 avoidanceVector = Vector2.zero;
            foreach (Collider2D obstacle in obstacles)
            {
                // Dodatkowy warunek sprawdzaj¹cy, czy przeszkoda ma odpowiednie otagowanie
                if (obstacle.CompareTag("Player"))
                {
                    continue; // Ignoruj przeszkody otagowane jako "Player"
                }

                avoidanceVector += (Vector2)transform.position - (Vector2)obstacle.transform.position;
            }
            rb.velocity = avoidanceVector.normalized * moveSpeed;
        }
        else
        {
            // Pod¹¿aj za celem
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Jeœli wystêpuje kolizja, zatrzymaj postaæ
        rb.velocity = Vector2.zero;
    }

    void UpdateAnimations()
    {
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("speed", rb.velocity.sqrMagnitude);

        if (rb.velocity != Vector2.zero)
        {
            // Ustawiamy flipX w zale¿noœci od kierunku ruchu
            if (rb.velocity.x < 0)
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