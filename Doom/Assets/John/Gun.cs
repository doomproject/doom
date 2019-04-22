using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    public float reloadTime = 5;
    [Tooltip("The higher the interval the faster the gun will fire.")]
    public float fireInterval = 1;
    public int damage = 1;
    public int clipSize = 5;
    public int currClip;
    public int ammo = 0;

	public ParticleSystem muzzleFlash;

    private float nextTimetoFire = 0;

    public void Fire()
    {
        if (currClip > 0 && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1 / fireInterval;
            currClip -= 1;
			muzzleFlash.Play();

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 100))
            {
                EnemyHealth EH = hit.transform.GetComponent<EnemyHealth>();
                if (EH != null)
                {
                    EH.TakeDamage(damage);
                }
            }
        }
    }

    public void Reload()
    {
        ammo += currClip;
        currClip = 0;
        StartCoroutine(ReloadingTime());
    }

    IEnumerator ReloadingTime()
    {
        yield return new WaitForSeconds(reloadTime);
        if (clipSize > ammo)
        {
            currClip = ammo;
            ammo = 0;
        }
        else
        {
            ammo -= clipSize;
            currClip = clipSize;
        }
    }
}
