using UnityEngine;
using System.Collections;

public class GlutBehavior : EnemyBehaviour 
{
	public override int damage{ get {return 30;}}
	public override int maxEnemyHP{ get {return 3;}}
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
