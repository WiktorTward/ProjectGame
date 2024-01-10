using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth = 0f;
    public float heartDropChance = 1f;
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

        Destroy(gameObject);

        GenerateHeart();
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
    void GenerateHeart()
    {
        if (Random.Range(0f, 1f) < heartDropChance && heart != null)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
    }
}
