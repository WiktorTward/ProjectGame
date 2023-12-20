using UnityEngine;

public class RedFollowCharacter : MonoBehaviour
{
    public Transform targetCharacter;
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f;

    private bool isFollowing = false;
    private EnemyShooting enemyShooting;

    void Start()
    {
        enemyShooting = GetComponent<EnemyShooting>();
    }

    void Update()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);

            if (distanceToTarget <= detectionRadius)
            {
                isFollowing = true;
            }

            if (isFollowing)
            {
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                transform.position += moveDirection * moveSpeed * Time.deltaTime;

                // Wywołujemy funkcję strzelania i przekazujemy pozycję postaci
                enemyShooting.Shoot(targetPosition);
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