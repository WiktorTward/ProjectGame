using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 0f;

    public Slider healthSlider; //slider do wyœwietlania HP na ekranie
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

    public void TakeDamge(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            EndGame();
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
        SceneManager.LoadScene("LVL_1");
    }
}
