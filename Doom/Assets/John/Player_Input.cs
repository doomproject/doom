using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{
	public GameObject currWeapon;
	IWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
		weapon = GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton("Fire1"))
		{
			weapon = currWeapon.GetComponent<IWeapon>(); //Look for the script on the object that the raycast hit.
			if (weapon != null) //If the script is on the gameobject.
			{
				weapon.Fire();
			}	
		}

		if (Input.GetKeyDown("r"))
		{
			weapon = currWeapon.GetComponent<IWeapon>(); //Look for the script on the object that the raycast hit.
			if (weapon != null) //If the script is on the gameobject.
			{
				weapon.Reload();
			}
		}
	}
}
