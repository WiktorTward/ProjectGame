// PlayerDetection.cs
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Transform targetCharacter;
    public float detectionRadius = 5.0f;

    public bool IsPlayerInRange()
    {
        if (targetCharacter != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetCharacter.position);
            return distanceToTarget <= detectionRadius;
        }

        return false;
    }
}