using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
	public float reloadTime = 5;
	public float fireInterval = 1;
	public int damage = 1;
	public int clipSize = 5;
	public int currClip;

	private float nextTimetoFire = 0;

	void Awake()
	{
		currClip = clipSize;
	}

	public void Fire()
	{
		if (currClip > 0 && Time.time >= nextTimetoFire)
		{
			nextTimetoFire = Time.time + 1 / fireInterval;
			currClip -= 1;

			RaycastHit hit;

			if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 100))
			{
				EnemyHealth EH = hit.transform.GetComponent<EnemyHealth>();
				if (EH != null)
				{
					EH.TakeDamage(damage);
				}
			}
		}
	}

	public void Reload()
	{
		currClip = clipSize;
	}

}
