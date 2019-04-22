using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Tooltip("The current weapon the player character is holding.")]
    private GameObject currWeapon;

    [Tooltip("The list of weapons that the player has.")]
    public List<GameObject> weaponList;

	Player_Input player;

    // Start is called before the first frame update
    void Start()
    {
		player = GetComponent<Player_Input>();
		currWeapon = weaponList[0];
		player.currWeapon = currWeapon;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
			currWeapon.gameObject.SetActive(false);
			currWeapon = weaponList[0]; //Set current weapon to the first weapon.
			player.currWeapon = currWeapon;
			currWeapon.gameObject.SetActive(true);
		}
        else if (Input.GetKeyDown("2")) //Etc.
        {
			currWeapon.gameObject.SetActive(false);
			currWeapon = weaponList[1];
			player.currWeapon = currWeapon;
			currWeapon.gameObject.SetActive(true);
		}
        else if (Input.GetKeyDown("3"))
        {
			currWeapon.gameObject.SetActive(false);
			currWeapon = weaponList[2];
			player.currWeapon = currWeapon;
			currWeapon.gameObject.SetActive(true);
		}
		else if (Input.GetKeyDown("4"))
		{
			currWeapon.gameObject.SetActive(false);
			currWeapon = weaponList[3];
			player.currWeapon = currWeapon;
			currWeapon.gameObject.SetActive(true);
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Pickup"))
        {

        }
    }
}
