using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth = 0f;
    public GameObject heart;

    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    public void TakeDamge(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    void Die()
    {
        ScoreManager.Instance.AddPoint();

        Destroy(gameObject);

        GenerateHeart();
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
    void GenerateHeart()
    {
        Instantiate(heart, transform.position, Quaternion.identity);
    }
}
