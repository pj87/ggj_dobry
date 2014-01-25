using UnityEngine;
using System.Collections;

public class GlutBehavior : EnemyBehaviour 
{
	public override int damage{ get {return 30;}}
	public override int maxEnemyHP{ get {return 3;}}

	public override void alertSound()
	{
	}

	public override void death()
	{
	}
}
