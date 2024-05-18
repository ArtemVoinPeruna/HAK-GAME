using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка, столкнулась ли пуля с врагом
        if (other.CompareTag("Enemy"))
        {
            
            
            // Уничтожение пули
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) // Если пуля не столкнулась с игроком
        {
            // Уничтожение пули
            Destroy(gameObject);
        }
    }
}


HealthBarController target = hitInfo.GetComponent<HealthBarController>();