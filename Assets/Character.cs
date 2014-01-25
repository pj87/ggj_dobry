using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float angle; 

	public Light visionALongLight;	//latarka
	public Light visionAShortLight;
	public Light visionBLight;	//niebieska
	public Light visionBTopLight;
	public Light visionCLight;	//czerwona

	private int visionMode = 0;	//tryb wizji, 0-latarka, 1-niebieska, 2-czerwona

	public AudioClip playerHit;
	public AudioClip playerDeath;
	public AudioClip playerStepA;
	public AudioClip playerStepB;
	public AudioClip playerStepFull;

	private int playerHP = 100;

	// Use this for initialization
	void Start ()
	{
		//ustawienie wizje na latarke
		visionALongLight.enabled = true;
		visionAShortLight.enabled = true;
		visionBLight.enabled = false;
		visionBTopLight.enabled = false;
		visionCLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
		//obsluga zmiany wizji
		if(Input.GetKeyDown(KeyCode.Q))
		{
			visionMode++;
			if(visionMode >= 3)
			{
				visionMode = 0;
			}

			Debug.Log(visionMode);
			if(visionMode == 0)	//latarka
			{
				visionALongLight.enabled = true;
				visionAShortLight.enabled = true;
				visionBLight.enabled = false;
				visionBTopLight.enabled = false;
				visionCLight.enabled = false;
			}
			if(visionMode == 1)	//niebieska
			{
				visionALongLight.enabled = false;
				visionAShortLight.enabled = false;
				visionBLight.enabled = true;
				visionBTopLight.enabled = true;
				visionCLight.enabled = false;
			}
			if(visionMode == 2)	//czerwona
			{
				visionALongLight.enabled = false;
				visionAShortLight.enabled = false;
				visionBLight.enabled = false;
				visionBTopLight.enabled = false;
				visionCLight.enabled = true;
			}
		}

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
        cameraPosition.Set(cameraPosition.x, 30f, cameraPosition.z);
        Camera.main.transform.position = cameraPosition;
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            Debug.Log("Finished LEVEL!!!!!"); 
            //audio.PlayOneShot(playerHit);
        }
    }

	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "Enemy") 
		{
			audio.PlayOneShot(playerHit);
		}
	}

	//gracz otrzymuje obrazenia
	public void reciveDamage(int damage)
	{
		Debug.Log (playerHP);
		if(playerHP - damage <= 0)
		{
			playerHP = 0;
			death();
		}else
		{
			playerHP = playerHP - damage;
		}
	}

	//gracz umarl
	void death()
	{
		//TODO mi gracza
		Debug.Log ("zgon");
	}
}
