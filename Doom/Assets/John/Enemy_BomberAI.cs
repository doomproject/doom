using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_BomberAI : MonoBehaviour
{
	[Tooltip("Distance that the enemy will move towards the player.")]
	[SerializeField] int distToMove = 30;
	[Tooltip("Distance that the enemy will explode at when near the player.")]
	[SerializeField] int explodeDistance = 2;
	[Tooltip("Damage that the enemy will deal upon explosion.")]
	[SerializeField] int explosionDamage = 10;
	[Tooltip("Particle effect for explosion when attacks.")]
	public GameObject explosionEffect;

	private GameObject player;
	private NavMeshAgent agent;
	private Animator anim;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		agent = gameObject.GetComponent<NavMeshAgent>();
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		float dist = Vector3.Distance(player.transform.position, this.transform.position);

		if (dist < explodeDistance)
		{
			Explode();
		}
		else if (dist < distToMove)
		{
			anim.SetBool("isWalking", true);
			agent.SetDestination(player.transform.position);
		}
		else
		{
			anim.SetBool("isWalking", false);
			agent.SetDestination(this.transform.position);
		}
	}

	void Explode() //Add customizable variables, finish script.
	{
		//Show explosion effect
		Instantiate(explosionEffect, this.transform.position, transform.rotation);

		//Get nearby objects, damage and add force.
		Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
		foreach (Collider nearbyObject in colliders)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.AddExplosionForce(5, this.transform.position, 5);

				if (rb.gameObject.CompareTag("Player"))
				{
					rb.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);
				}
			}
		}

		Destroy(this.gameObject);
	}
}
