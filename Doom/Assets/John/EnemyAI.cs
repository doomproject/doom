using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
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
		agent.SetDestination(player.transform.position);
    }
}
