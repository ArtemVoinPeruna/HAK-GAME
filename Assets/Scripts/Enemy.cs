using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное количество здоровья
    private int currentHealth; // Текущее количество здоровья

    public Slider healthSlider; // Ссылка на слайдер здоровья

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        // Обновление позиции слайдера здоровья
        // healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        healthSlider.value = currentHealth;
    }

    void Die()
    {
        // Логика смерти врага
        Destroy(gameObject);
    }
}
