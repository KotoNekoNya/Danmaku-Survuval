using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public float MovementSpeed = 1;
    public float HorizontalBorder = 2.6f;
    public float VerticalBorder = 4.0f;

    public static PlayerController main;

    public Vector3 moveAmount;

    public Weapon[] Weapons;

    public GameObject gameOverMenu;

    private bool isAlive = true;
    private bool isGameOver = false;

    private Vector3 touchStartPosition; // Позиция начала касания
    private Vector3 touchEndPosition; // Позиция окончания касания
    private bool isTouching = false; // Флаг для отслеживания касания

    private void Awake()
    {
        main = this;
    }

    void Update()
    {
        if (isGameOver)
            return;
        if (!isAlive)
            return;

        // Отслеживаем касания на экране
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchEndPosition = touch.position;
                Vector3 touchDelta = touchEndPosition - touchStartPosition;
                moveAmount = new Vector3(touchDelta.x, touchDelta.y, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
                moveAmount = Vector3.zero;
            }
        }
        else
        {
            isTouching = false;
            moveAmount = Vector3.zero;
        }

        // Нормализуем вектор направления движения
        moveAmount.Normalize();

        // Перемещаем персонаж на основе вектора движения и скорости
        transform.position += moveAmount * Time.deltaTime * MovementSpeed;

        // Ограничиваем персонажа в пределах границ
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -HorizontalBorder, HorizontalBorder),
            Mathf.Clamp(transform.position.y, -VerticalBorder, VerticalBorder),
            transform.position.z
        );

        // Выполняем огонь оружия после определенного времени
        if (Time.timeSinceLevelLoad > 2.0f)
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.Fire();
            }
        }
    }

    public override void Die()
    {
        if (isGameOver)
            return;

        isGameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0; // Останавливаем время в игре
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity other = collision.gameObject.GetComponent<Entity>();

        if (other == null) return;
        if (other is Enemy)
        {
            Damage(5.0f);
        }
    }
}
