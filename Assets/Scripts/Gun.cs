using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;   // Префаб пули
    public Transform firePoint;       // Точка стрельбы
    public float bulletSpeed = 20f;   // Скорость пули

    public Joystick joystick;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsTouchOverUI(Input.mousePosition))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // Устанавливаем z-координату, чтобы корректно преобразовать в мировые координаты

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            firePoint.transform.LookAt(worldPosition, Vector3.forward);



            Shoot(worldPosition);
        }
        // Проверка на касание экрана
        // if (Input.touchCount > 0 && !IsTouchOverUI(Input.GetTouch(0).position))
        // {
        //     Touch touch = Input.GetTouch(0);

        //     // Если касание началось
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         firePoint.transform.LookAt(touch.position, Vector3.forward);
        //         Shoot(touch.position);
        //     }
        // }
    }

    void Shoot(Vector3 touchPosition)
    {
        // Преобразование позиции касания из экранных координат в мировые координаты
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.nearClipPlane));

        // Создание пули
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Получение направления стрельбы
        Vector2 direction = (touchPosition - firePoint.position).normalized;

        // Добавление силы к пуле
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }

        // Проверка, находится ли касание над UI элементом
    bool IsTouchOverUI(Vector2 touchPosition)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        // Проверка, есть ли объект UI под касанием
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        // Проверка, есть ли среди них джойстик
        foreach (var result in results)
        {
            if (result.gameObject == joystick.gameObject)
            {
                return true;
            }
        }

        return false;
    }
}
