using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile Projectile;
    public Entity Parent;
    public float FireRate;
    public float _cooldown;
    public AudioClip FireSound;
    public float FireVolume;

    public virtual void Fire()
    {
        if (_cooldown > 0) return;
        Projectile newProjectile = Instantiate(Projectile, transform.position, Parent.transform.rotation);
        newProjectile.OwnedBy = Parent;
        _cooldown = FireRate;
        StartCoroutine(DestroyOverSeconds(5.0f, newProjectile.gameObject));
        PlaySound();
    }

    public void PlaySound()
    {
        if (FireSound == null) return;
        GameObject newAC = new GameObject();
        AudioSource audioSource = newAC.AddComponent<AudioSource>();
        audioSource.volume = FireVolume;
        audioSource.PlayOneShot(FireSound);
        StartCoroutine(DestroyOverSeconds(FireSound.length + 0.1f, newAC));
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;
    }

    public IEnumerator DestroyOverSeconds(float time, GameObject go)
    {
        yield return new WaitForSeconds(time);
        Destroy(go);
    }
}
