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

	private List<GameObject> gunList;
	[SerializeField] GameObject[] icon;
	private GameObject currIcon;

    private PlayerHealth playerHealth;
	private PlayerInventory playerWeapon;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

		gunList = playerWeapon.weaponList;
		currIcon = icon[0];
	}

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        healthText.text = playerHealth.currentHealth.ToString();
        shieldBar.fillAmount = (float)playerHealth.currentArmor / playerHealth.maxArmor;
        shieldText.text = playerHealth.currentArmor.ToString();

		#region Player Icon Set
		for (int i = 0; i < icon.Length; i++)
		{
			if (playerWeapon.currWeapon == playerWeapon.weaponList[i])
			{
				currIcon.gameObject.SetActive(false);
				currIcon = icon[i];
				currIcon.gameObject.SetActive(true);
			}
		}
		#endregion

		if (playerWeapon.currWeapon.GetComponent<Gun>() != null)
		{
			ammoText.text = playerWeapon.currWeapon.GetComponent<Gun>().ammo.ToString();
		}
		else
		{
			ammoText.text = "-";
		}
	}
}
