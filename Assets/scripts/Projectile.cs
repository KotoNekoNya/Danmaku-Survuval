using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 5.0f;
    public float Damage = 5.0f;
    public Entity OwnedBy;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity hitEntity = collision.gameObject.GetComponent<Entity>();
        if (hitEntity == null) return;
        if (hitEntity is PlayerController && OwnedBy is PlayerController) return;
        if (hitEntity is Enemy && OwnedBy is Enemy) return;

        hitEntity.Damage(Damage);

        Destroy(gameObject);
    }
}
