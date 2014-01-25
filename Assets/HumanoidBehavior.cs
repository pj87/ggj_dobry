using UnityEngine;
using System.Collections;

public class HumanoidBehavior : EnemyBehaviour 
{
	public override int damage{ get {return 20;}}
	public override int maxEnemyHP{ get {return 1;}}
	public AudioClip enemyAlert;
	public AudioClip enemyDeath;

	public override void alertSound()
	{
		audio.PlayOneShot(enemyAlert);
	}
	
	public override void death()
	{
		audio.PlayOneShot(enemyDeath);
		Destroy (gameObject, 1);
	}
}
