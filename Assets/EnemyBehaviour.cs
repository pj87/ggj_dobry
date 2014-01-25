using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private int i = 0;

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
        var distanceToPlayerVector = player.transform.position - this.transform.position;
        var sqrOfDistanceToPlayer = distanceToPlayerVector.sqrMagnitude;
        if (sqrOfDistanceToPlayer < 1 || sqrOfDistanceToPlayer < 9 && Vector3.Angle(distanceToPlayerVector, transform.forward) < 45f)
        {
            _animator.SetBool("IsAttacking", true);
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }

        if (sqrOfDistanceToPlayer <= 25)
        {
            if ((i++) % 5 == 0)
            {
                agent.SetDestination(player.transform.position);
            }
        }
        else
        {
            if ((i++) % 60 == 0)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
}
