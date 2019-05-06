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

	public Text ammoText;

    private PlayerHealth playerHealth;
	private Player_Input playerWeapon;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Input>();
	}

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        healthText.text = playerHealth.currentHealth.ToString();
        shieldBar.fillAmount = (float)playerHealth.currentArmor / playerHealth.maxArmor;
        shieldText.text = playerHealth.currentArmor.ToString();

		if (playerWeapon.currWeapon.GetComponent<Gun>() != null)
		{
			ammoText.text = playerWeapon.currWeapon.GetComponent<Gun>().ammo.ToString();
		}
		else
		{
			ammoText.text = "0";
		}
	}
}
