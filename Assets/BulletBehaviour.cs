using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        //collision.collider.gameObject 
        Debug.Log("Collision with other objects...");
        Destroy(gameObject);
    } 
}
