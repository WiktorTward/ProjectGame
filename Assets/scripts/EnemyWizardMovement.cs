

using UnityEngine;

public class EnemyWizardMovement : MonoBehaviour
{
    public Transform targetCharacter;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 200f;
    public float detectionRadius = 5.0f;
    public float stopFollowRadius = 7.0f;
    public float maintainDistance = 3.0f;
    public float shootCooldown = 2.0f;
    public float projectileSpeed = 5.0f;
    private float timeSinceLastShot = 0.0f;
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Rigidbody2D rb;
    Vector2 movement;

    private bool isFollowing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Ruch postaci
        Move();

        // Strzelanie
        Shoot();

        // Animacje
        UpdateAnimations();
    }

    void Move()
    {
        Vector2 enemyMovement = GetEnemyMovementVector();

        // Oblicz odległość od postaci-cele
        float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

        // Sprawdź, czy przeciwnik jest w zasięgu wykrywania i czy odległość jest większa niż minimalna utrzymywana odległość
        if (distanceToTarget <= detectionRadius && distanceToTarget > maintainDistance)
        {
            // Ustaw wektor ruchu przeciwnika
            rb.velocity = enemyMovement * moveSpeed;

            // Obracaj postać w kierunku ruchu
            //if (enemyMovement != Vector2.zero)
            //{
            //    float angle = Mathf.Atan2(enemyMovement.y, enemyMovement.x) * Mathf.Rad2Deg;
            //    rb.rotation = Mathf.MoveTowardsAngle(rb.rotation, angle, rotationSpeed * Time.deltaTime);
            //}
        }
        else
        {
            // Jeśli przeciwnik nie jest w zasięgu lub jest zbyt blisko, zatrzymaj go
            rb.velocity = Vector2.zero;
        }
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
            else if (isFollowing && distanceToTarget <= stopFollowRadius)
            {
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                return new Vector2(moveDirection.x, moveDirection.y);
            }
        }

        return Vector2.zero;
    }

    void Shoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootCooldown)
        {
            if (projectilePrefab != null && firePoint != null)
            {
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
                Vector2 shootDirection = (targetCharacter.position - firePoint.position).normalized;

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                if (projectileRb != null)
                {
                    projectileRb.velocity = shootDirection * projectileSpeed;
                }
                else
                {
                    Debug.LogError("Brak komponentu Rigidbody2D na prefabie pocisku.");
                }

                timeSinceLastShot = 0.0f;
            }
            else
            {
                Debug.LogError("Prefab pocisku lub punkt strzału nie są zdefiniowane.");
            }
        }
    }

    void UpdateAnimations()
    {
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("speed", rb.velocity.sqrMagnitude);

        if (rb.velocity != Vector2.zero)
        {
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }
}

