using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Tooltip("The amount of damage the enemy deals to the player.")]
    public int damage = 5;
    [Tooltip("Cooldown which the enemy attacks at when 0.")]
    [SerializeField] float atkCooldown = 5;

    //Player gameobject.
	private GameObject player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
    {
		atkCooldown -= Time.deltaTime;
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.gameObject == player)
		{
			if (atkCooldown < 0)
			{
				atkCooldown = 5;
				player.GetComponent<PlayerHealth>().TakeDamage(damage);
			}
		}
	}
}
