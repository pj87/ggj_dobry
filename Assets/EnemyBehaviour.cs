using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private int pathFinding = 0;
	private int atak = 0;

    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		var distanceToPlayerVector = (player.transform.position - this.transform.position);
		var distanceToPlayer = (player.transform.position - this.transform.position).magnitude;
//        var sqrOfDistanceToPlayer = distanceToPlayerVector.sqrMagnitude;
		if (distanceToPlayer < 3 && Vector3.Angle(distanceToPlayerVector, transform.forward) < 45f)
        {
            _animator.SetBool("IsAttacking", true);

			if ((atak++) % 30 == 0) 
			{
				//zabieranie zycia graczowi
				player.GetComponent<player>.recieveDamage(5);
			}

        }
        else
        {
            _animator.SetBool("IsAttacking", false);
			atak=0;
        }

		if (distanceToPlayer <= 50) 
		{
			if (distanceToPlayer <= 8) 
			{
				if ((pathFinding++) % 5 == 0) 
				{
					agent.SetDestination (player.transform.position);
				}
			} else 
			{
				if ((pathFinding++) % 30 == 0) 
				{
					agent.SetDestination (player.transform.position);
				}
			}
		}
    }
}
