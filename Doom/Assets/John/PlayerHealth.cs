using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Player's max health.")]
    int maxHealth = 100;
    public int currentHealth = 100;

    int maxArmor = 50;
    public int currentArmor = 50;

    void Awake()
    {
        currentHealth = maxHealth;
        currentArmor = maxArmor;
    }

    void TakeDamage(int damage)
    {
        if (currentArmor > 0) //If armor is greater than 0.
        {
            if (damage > currentArmor) //If damage is greater than armor, deal damage to armor then health.
            {
                int totalDamage = damage - currentArmor; //Take damage minus the armor.
                currentArmor = 0;

                currentHealth -= totalDamage; //Deal remaining damage to the player.
            }
            else
            {
                currentArmor -= damage; //Else damage is greater than armor, deal damage to armor.
            }
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }
}
