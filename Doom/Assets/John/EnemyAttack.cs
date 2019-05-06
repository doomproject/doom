using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Tooltip("The amount of damage the enemy deals to the player.")]
    public int damage = 5;
    [Tooltip("The higher the interval the faster the enemy will attack.")]
    public float fireInterval = 1;
    [Tooltip("The range of the enemy.")]
    public int range = 10;

	[Tooltip("The flash for when the weapon fires.")]
	public GameObject fireEffect;
	[Tooltip("The position to fire from.")]
	public Transform barrelEnd;
	//Player gameobject.
	private GameObject player;

    private float nextTimetoFire = 0;
	private Animator animator;

    private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		animator = this.gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
    {
        if (Time.time >= nextTimetoFire)
        {
			animator.SetBool("Shooting", false);
			nextTimetoFire = Time.time + 1 / fireInterval;
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, player.transform.position - this.transform.position, out hit, range))
            {
				animator.SetBool("Shooting", true);
				Instantiate(fireEffect, barrelEnd.transform.position, barrelEnd.transform.rotation);

				PlayerHealth PH = hit.transform.GetComponent<PlayerHealth>();
                if (PH != null)
                {
                    PH.TakeDamage(damage);
                }
            }
        }
    }
}