using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public float MovementSpeed = 1;
    public float HorizontalBorder = 4.0f;
    public float VerticalBorder = 4.0f;

    public static PlayerController main;

    public Vector3 moveAmount;

    public Weapon[] Weapons;

    private void Awake()
    {
        main = this;
    }

    void Update()
    {
        moveAmount += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * MovementSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * MovementSpeed, 0);
        Vector3 moveDiff = moveAmount * Time.deltaTime * 8;
        transform.position += moveDiff;
        moveAmount -= moveDiff;

        if (transform.position.x < -HorizontalBorder) transform.position = new Vector3(-HorizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.x > HorizontalBorder) transform.position = new Vector3(HorizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.y < -VerticalBorder) transform.position = new Vector3(transform.position.x, - VerticalBorder, transform.position.z);
        if (transform.position.y > VerticalBorder) transform.position = new Vector3(transform.position.x, VerticalBorder, transform.position.z);

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
        base.Die();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
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
