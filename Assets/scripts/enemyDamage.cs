using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Damage inflicted on the player.
    public int enemyDamage;

    // Inflict damage when colliding with the player.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player.
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject and apply damage.
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
    }
}

