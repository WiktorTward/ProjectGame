using UnityEngine;

public class GreenFollowCharacter : MonoBehaviour
{
    public Transform targetCharacter; // Referencja do postaci, za kt�r� pod��amy
    public float moveSpeed = 3.0f;
    public float detectionRadius = 5.0f; // Promie� detekcji postaci
    public float escapeRadius = 10.0f; // Dalszy zasi�g, poza kt�rym przeciwnik przestanie pod��a�

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

            // Sprawdzamy, czy posta� jest w zasi�gu
            if (distanceToTarget <= detectionRadius)
            {
                // Obliczamy kierunek ruchu
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Ruch w kierunku postaci
                transform.position += moveDirection * moveSpeed * Time.deltaTime;

                // Aktywacja animacji w zale�no�ci od kierunku ruchu
                ActivateMovementAnimation(moveDirection);
            }
            else if (distanceToTarget > detectionRadius && distanceToTarget <= escapeRadius)
            {
                // Je�li posta� przekroczy zasi�g detekcji, ale jest w zasi�gu ucieczki
                Vector3 targetPosition = targetCharacter.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                // Ruch w kierunku postaci, ale z mniejsz� pr�dko�ci� (mo�esz dostosowa�)
                transform.position += moveDirection * (moveSpeed / 2) * Time.deltaTime;

                // Aktywacja animacji w zale�no�ci od kierunku ruchu
                ActivateMovementAnimation(moveDirection);
            }
            else
            {
                // Posta� opu�ci�a zasi�g ucieczki - zatrzymaj przeciwnika
                // Mo�esz r�wnie� ustawi� przeciwnika na konkretn� pozycj�, aby unikn�� fluktuacji
                // transform.position = transform.position;

                // Zatrzymaj animacj� ruchu
                DeactivateMovementAnimation();
            }
        }
    }

    void ActivateMovementAnimation(Vector3 moveDirection)
    {
        // Aktywacja animacji w zale�no�ci od kierunku ruchu
        float angle = Vector3.SignedAngle(Vector3.forward, moveDirection, Vector3.up);
        Debug.Log(angle);
        if (angle >= -45f && angle < 45f)
        {
            // Ruch w prz�d
            animator.SetBool("IsMovingForward", true);
        }
        else if (angle >= 45f && angle < 135f)
        {
            // Ruch w prawo
            animator.SetBool("IsMovingRight", true);
        }
        else if (angle >= 135f || angle < -135f)
        {
            // Ruch w ty�
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
