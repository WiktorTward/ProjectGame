using UnityEngine;

public class GreenFollowCharacter : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za któr¹ pod¹¿amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promieñ detekcji postaci
    public float escapeRadius = 10.0f; // Dalszy zasiêg, poza którym przeciwnik przestanie pod¹¿aæ

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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

                // Aktywacja animacji w zale¿noœci od kierunku ruchu
                ActivateMovementAnimation(moveDirection);
            }
            else if (distanceToTarget > detectionRadius && distanceToTarget <= escapeRadius)
            {
                // Jeœli postaæ przekroczy zasiêg detekcji, ale jest w zasiêgu ucieczki
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Ruch w kierunku postaci, ale z mniejsz¹ prêdkoœci¹ (mo¿esz dostosowaæ)
                transform.position += moveDirection * (moveSpeed / 2) * Time.deltaTime;

                // Aktywacja animacji w zale¿noœci od kierunku ruchu
                ActivateMovementAnimation(moveDirection);
            }
            else
            {
                // Postaæ opuœci³a zasiêg ucieczki - zatrzymaj przeciwnika
                // Mo¿esz równie¿ ustawiæ przeciwnika na konkretn¹ pozycjê, aby unikn¹æ fluktuacji
                // transform.position = transform.position;

                // Zatrzymaj animacjê ruchu
                DeactivateMovementAnimation();
            }
        }
    }

    void ActivateMovementAnimation(Vector3 moveDirection)
    {
        // Aktywacja animacji w zale¿noœci od kierunku ruchu
        float angle = Vector3.SignedAngle(Vector3.forward, moveDirection, Vector3.up);
        Debug.Log(angle);
        if (angle >= -45f && angle < 45f)
        {
            // Ruch w przód
            animator.SetBool("IsMovingForward", true);
        }
        else if (angle >= 45f && angle < 135f)
        {
            // Ruch w prawo
            animator.SetBool("IsMovingRight", true);
        }
        else if (angle >= 135f || angle < -135f)
        {
            // Ruch w ty³
            animator.SetBool("IsMovingBackward", true);
        }
        else if (angle >= -135f && angle < -45f)
        {
            // Ruch w lewo
            animator.SetBool("IsMovingLeft", true);
        }
    }

    void DeactivateMovementAnimation()
    {
        // Zatrzymaj wszystkie animacje ruchu
        animator.SetBool("IsMovingForward", false);
        animator.SetBool("IsMovingRight", false);
        animator.SetBool("IsMovingBackward", false);
        animator.SetBool("IsMovingLeft", false);
    }
}
