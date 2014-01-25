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
        //collision.collider.gameObject 
        //Debug.Log("Collision with other objects..."); 
        //if (collision.gameObject.layer == enemyLayer)
        if (collision.collider.gameObject.name == "pajenczak") 
            Debug.Log("Collision with pajeczak..."); 
        Destroy(gameObject);
    } 
}
