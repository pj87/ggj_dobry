using UnityEngine;
using System.Collections;

public class enemyChaseScript : MonoBehaviour 
{
	private NavMeshAgent agent;
	private GameObject player;
	private int i = 0;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag("Player");
		//InvokeRepeating ("pathUpdate", 0, 1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( (i++)%30 == 0) 
		{
			agent.SetDestination (player.transform.position);
		}
	}

	void pathUpdate()
	{
		//agent.SetDestination (player.transform.position);
	}
}
