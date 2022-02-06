using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Weapon[] Weapons;
    public void Disappear()
    {
        Destroy(gameObject);
    }

    public void Fire()
    {
        if (Weapons.Length == 0) return;
        foreach(Weapon weapon in Weapons)
        {
            weapon.Fire();
        }
    }
}
