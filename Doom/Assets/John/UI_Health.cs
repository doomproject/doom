using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    public Image healthBar;
    public Image shieldBar;

    public Text healthText;
    public Text shieldText;

    private PlayerHealth player;
    IWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)player.currentHealth / player.maxHealth;
        healthText.text = player.currentHealth.ToString();
        shieldBar.fillAmount = (float)player.currentArmor / player.maxArmor;
        shieldText.text = player.currentArmor.ToString();
    }
}
