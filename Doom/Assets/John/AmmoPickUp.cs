using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour, IPickup
{
    public GameObject weapon;
    public int ammoAmount = 7;

    private void Start()
    {
        if (weapon == null)
        {
            Debug.LogError("Weapon has not been set for ammo pickup, please set a weapon.");
        }
    }

    public void Pickup()
    {
        weapon.GetComponent<Gun>().ammo += ammoAmount;
        Destroy(this.gameObject);
    }
}
