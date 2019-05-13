using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	[Tooltip("Distance that the enemy will move towards the player.")]
	[SerializeField] int distToMove = 30;
	[Tooltip("Distance that the enemy will stop at when near the player.")]
	[SerializeField] int stopDistance = 10;

	private GameObject player;
	private NavMeshAgent agent;

    void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
		float dist = Vector3.Distance(player.transform.position, this.transform.position);
		if (dist < stopDistance)
		{
			agent.SetDestination(this.transform.position);

			transform.LookAt(player.transform.position);
		}
		else if (dist < distToMove)
		{
			agent.SetDestination(player.transform.position);
		}

	}
}
