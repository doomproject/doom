using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour, IWeapon
{
	[SerializeField] int range = 100;
	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Fire()
	{
		RaycastHit hit;

		//Check the raycast to see if it hit an object with the grapple tag.
		if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range) && hit.transform.tag == "Grapple")
		{
			player.transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, 5 * Time.deltaTime);
		}
	}

	public void Reload()
	{
		//Nothing
	}

}
