using UnityEngine;

public class GreenFollowCharacter : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za któr¹ pod¹¿amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promieñ detekcji postaci

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
    }
}