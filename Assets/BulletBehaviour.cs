using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	int damage=1;
    int enemyLayer;

	// Use this for initialization
	void Start () {
        enemyLayer = LayerMask.NameToLayer("enemy");
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
			collision.gameObject.GetComponent<EnemyBehaviour>().recieveDamage(damage);
        } 
        Destroy(gameObject); 
    } 
}
