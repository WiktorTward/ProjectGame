using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    public int scoreValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoint();
            Destroy(gameObject);
        }
    }
}

