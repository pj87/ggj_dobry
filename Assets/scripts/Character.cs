using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float angle; 

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 moveVector = new Vector3();
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        if (hAxis != 0)
        {
            moveVector.x = hAxis > 0 ? 1f : -1f;
        }
        if (vAxis != 0)
        {
            moveVector.z = vAxis > 0 ? 1f : -1f;
        }
        transform.position += moveVector * 0.1f;
        
        //Vector3 speed : Vector3 = Vector3 (3, 0, 0);
        rigidbody.MovePosition(transform.position + moveVector * Time.deltaTime); 
        if(hAxis > 0 && vAxis == 0)
        {
            angle = 0;
        }
        else if(hAxis > 0 && vAxis > 0)
        {
            angle = -45f;
        }
        else if(hAxis == 0 && vAxis > 0)
        {
            angle = -90f;
        }
        else if(hAxis < 0 && vAxis > 0)
        {
            angle = -135f;
        }
        else if(hAxis < 0 && vAxis == 0)
        {
            angle = -180f;
        }
        else if(hAxis < 0 && vAxis < 0)
        {
            angle = -225f;
        }
        else if(hAxis == 0 && vAxis < 0)
        {
            angle = -270f;
        }
        else if(hAxis > 0 && vAxis < 0)
        {
            angle = -315f;
        } 

        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, angle - 270, 0); 

        var cameraPosition = this.transform.position;
        cameraPosition.Set(cameraPosition.x, 10f, cameraPosition.z);
        Camera.main.transform.position = cameraPosition;
	}
}
