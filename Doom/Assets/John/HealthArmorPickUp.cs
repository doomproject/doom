using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthArmorPickUp : MonoBehaviour, IPickup
{
    private PlayerHealth player;
    public int healthAmount = 10;
    public int armorAmount = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    public void Pickup()
    {
        player.currentHealth += healthAmount;
        player.currentArmor += armorAmount;
        Destroy(this.gameObject);
    }

}
