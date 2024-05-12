using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the player
    public float currentHealth = 0f; // Current health of the player

    public Slider healthSlider; // Slider for displaying HP on the screen

    void Start()
    {
        currentHealth = maxHealth; // Set current health to maximum health at the start
        UpdateHealthUI(); // Update health UI
    }

    // Handle collision with heart pickup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart"))
        {
            GainHealth(10); // Increase player health by 10
            Destroy(collision.gameObject); // Destroy the heart pickup
        }
    }

    // Inflict damage on the player
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Decrease player health by the damage amount
        UpdateHealthUI(); // Update health UI

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Ensure health doesn't go below zero
            EndGame(); // End the game if player health reaches zero
        }
    }

    // Update the health UI slider
    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    // Increase player health
    void GainHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // Ensure health doesn't exceed maximum health
        UpdateHealthUI(); // Update health UI
    }

    // End the game
    void EndGame()
    {
        SceneManager.LoadScene("LVL_1"); // Load the specified scene (e.g., restart the level)
    }
}

