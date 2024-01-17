using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public Slider healthSlider;
    public UIManager uiManager;
    public AudioSource deathSound;

    bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart"))
        {
            GainHealth(10);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;
            UpdateHealthUI();
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
                PlayDeathSound();
                EndGame();
                Destroy(gameObject);
            }
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    void GainHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();
    }

    void EndGame()
    {
        if (uiManager != null)
        {
            uiManager.ShowGameOverMenu();
        }
    }

    void PlayDeathSound()
    {
        if (deathSound != null)
        {
            deathSound.Play();
        }
    }
}