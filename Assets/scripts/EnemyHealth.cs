using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Maximum health of the enemy
    public float maxHealth = 50f;

    // Current health of the enemy
    public float currentHealth = 0f;

    // Chance of dropping a heart upon death
    public float heartDropChance = 1f;

    // Reference to the heart GameObject
    public GameObject heart;

    // Reference to the health slider UI element
    public Slider healthSlider;

    void Start()
    {
        // Set current health to maximum health at the start
        currentHealth = maxHealth;

        // Update the health UI
        UpdateHealthUI();
    }

    // Reduce enemy health by the given amount
    public void TakeDamage(int damageAmount)
    {
        // Decrease current health by the damage amount
        currentHealth -= damageAmount;

        // Update the health UI
        UpdateHealthUI();

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            // Ensure health doesn't go below zero
            currentHealth = 0;

            // Perform actions for when the enemy dies
            Die();
        }
    }

    // Handle enemy death.
    void Die()
    {
        // Destroy the enemy GameObject
        Destroy(gameObject);

        // Generate a heart drop if conditions are met
        GenerateHeart();
    }

    // Update the health UI slider
    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    // Generate a heart drop with a certain chance
    void GenerateHeart()
    {
        // Check if a heart drop should be generated based on chance and if the heart prefab is assigned
        if (Random.Range(0f, 1f) < heartDropChance && heart != null)
        {
            // Instantiate the heart GameObject at the enemy's position
            Instantiate(heart, transform.position, Quaternion.identity);
        }
    }

    internal void TakeDamge(int bulletDamage)
    {
        throw new System.NotImplementedException();
    }
}

