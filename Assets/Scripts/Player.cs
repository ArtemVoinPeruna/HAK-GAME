using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public HealthBarController playerHealth;
    public float speed = 10f;
    public FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

   

        gameObject.transform.position += new Vector3(moveX, moveY, 0) * speed *Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finish") {
            Debug.Log("Работаю");
            playerHealth.TakeDamage(10);
        }
    }
}
