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

    //Player gameobject.
    private GameObject player;

    private float nextTimetoFire = 0;

    private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
    {
        if (Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1 / fireInterval;
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
            {
                PlayerHealth PH = hit.transform.GetComponent<PlayerHealth>();
                if (PH != null)
                {
                    PH.TakeDamage(damage);
                }
            }
        }
    }
}
