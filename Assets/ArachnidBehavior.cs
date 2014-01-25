using UnityEngine;
using System.Collections;

public class ArachnidBehavior : EnemyBehaviour 
{
	public override int damage{ get {return 10;}}
	public override int maxEnemyHP{ get {return 1;}}
	
	public override void alertSound()
	{
	}
	
	public override void death()
	{
	}
}
