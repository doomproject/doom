using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{



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
			weapon.Fire();
		}

		if (Input.GetKeyDown("r"))
		{
			weapon.Reload();
		}
	}
}
