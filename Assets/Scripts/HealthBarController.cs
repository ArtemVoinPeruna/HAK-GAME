using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;  // Ссылка на слайдер HP
    public int maxHealth = 100;  // Максимальное значение HP
    private int currentHealth;   // Текущее значение HP

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Функция для нанесения урона
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;
    }

    // Функция для восстановления здоровья
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
    }
}
