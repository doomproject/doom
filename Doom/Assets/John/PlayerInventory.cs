using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Tooltip("The current weapon the player character is holding.")]
    public GameObject currWeapon;
    [Tooltip("The current ammo for the shotgun that the player has.")]
    public int shotgunAmmo = 0;


    [Tooltip("The list of weapons that the player has.")]
    public List<GameObject> weaponList;

    // Start is called before the first frame update
    void Start()
    {
        //weaponList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            currWeapon = weaponList[0]; //Set current weapon to the first weapon.
        }
        else if (Input.GetKeyDown("2")) //Etc.
        {
            currWeapon = weaponList[1];
        }
        else if (Input.GetKeyDown("3"))
        {
            currWeapon = weaponList[2];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Pickup"))
        {

        }
    }
}
