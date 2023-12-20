using UnityEngine;

public class RedFollowCharacter : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za kt�r� pod��amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promie� detekcji postaci

    private bool isFollowing = false; // Flaga okre�laj�ca, czy przeciwnik powinien pod��a�

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

                // Ruch w kierunku postaci
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}
