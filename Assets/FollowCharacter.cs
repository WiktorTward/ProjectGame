using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za któr¹ pod¹¿amy
    public float moveSpeed = 3.0f;

    void Update()
    {
        if (targetCharacter != null)
        {
            Vector3 targetPosition = targetCharacter.position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
