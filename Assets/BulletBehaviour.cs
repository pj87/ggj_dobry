using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

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
            Debug.Log("Collision with pajeczak..."); 
            Destroy(collision.gameObject); 
        } 
        Destroy(gameObject); 
    } 
}
