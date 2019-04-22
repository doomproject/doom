using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IWeapon
{
    [Tooltip("The higher the interval the faster the knife will hit.")]
    public float fireInterval = 1;
    [Tooltip("The amount of damage the knife does.")]
    public int damage = 1;
    [Tooltip("The range of the knife.")]
    public int range = 10;

    private float nextTimetoFire = 0;

    public void Fire()
    {
        if (Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1 / fireInterval;
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
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
        //Nothing
    }

}
