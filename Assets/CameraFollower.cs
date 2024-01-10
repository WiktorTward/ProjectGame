using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float Speed = 0.125f; 

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Speed);
            transform.position = smoothedPosition;
        }
    }
}