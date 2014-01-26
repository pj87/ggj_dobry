using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float angle; 
	private bool alive = true;

	public Light visionALongLight;	//latarka
	public Light visionAShortLight;
	public Light visionBLight;	//niebieska
	public Light visionBTopLight;
	public Light visionCLight;	//czerwona

	private int visionMode = 0;	//tryb wizji, 0-latarka, 1-niebieska, 2-czerwona

    public int VisionMode { get { return visionMode; } }

	public AudioClip visionA;//dzwieki do zmieniania wizji
	public AudioClip visionB;
	public AudioClip visionC;
		
	public AudioClip playerHit;
	public AudioClip playerDeath;
	public AudioClip playerStepA;
	public AudioClip playerStepB;
	public AudioClip playerStepFull;

    public int maxPlayerHP = 100;
	private int playerHP;
	private float speed = 1.5f;
    private GameObject mainCamera_; 

    public int getPlayerHp()
    {
        return playerHP; 
    }

	// Use this for initialization
	void Start ()
	{
        playerHP = maxPlayerHP;

		//ustawienie wizje na latarke
		visionALongLight.enabled = true;
		visionAShortLight.enabled = true;
		visionBLight.enabled = false;
		visionBTopLight.enabled = false;
		visionCLight.enabled = false;

        mainCamera_ = GameObject.Find("Main Camera"); 
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(alive)
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
					audio.PlayOneShot(visionA);
					visionALongLight.enabled = true;
					visionAShortLight.enabled = true;
					visionBLight.enabled = false;
					visionBTopLight.enabled = false;
					visionCLight.enabled = false;
				}
				if(visionMode == 1)	//niebieska
				{
					audio.PlayOneShot(visionB);
					visionALongLight.enabled = false;
					visionAShortLight.enabled = false;
					visionBLight.enabled = true;
					visionBTopLight.enabled = true;
					visionCLight.enabled = false;
				}
				if(visionMode == 2)	//czerwona
				{
					audio.PlayOneShot(visionC);
					visionALongLight.enabled = false;
					visionAShortLight.enabled = false;
					visionBLight.enabled = false;
					visionBTopLight.enabled = false;
					visionCLight.enabled = true;
				}
			}

			//obsluga chodzenia
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
	        transform.position += (moveVector * 0.1f)*speed;
	       
	        rigidbody.MovePosition(transform.position + moveVector * Time.deltaTime); 

			//obsluga myszy
			var observationPoint = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
			observationPoint.y = 0.5f;
			transform.LookAt(observationPoint);

	        var cameraPosition = this.transform.position;
	        cameraPosition.Set(cameraPosition.x, 30f, cameraPosition.z);
	        Camera.main.transform.position = cameraPosition;
		}
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            mainCamera_.GetComponent<EndLevel>().setPlayerFinished(true); 
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
		if(alive)
		{
			audio.PlayOneShot(playerHit);
			if(playerHP - damage <= 0)
			{
				playerHP = 0;
				death();
			}else 
			{
				playerHP = playerHP - damage;
			}
		}
	}

	//gracz umarl
	void death()
	{
		alive = false;

		audio.PlayOneShot(playerDeath);

		gameObject.GetComponentInChildren<Shooting> ().playerDeath ();

		visionALongLight.enabled = false;
		visionAShortLight.enabled = false;
		visionBLight.enabled = false;
		visionBTopLight.enabled = false;
		visionCLight.enabled = false;
        mainCamera_.GetComponent<EndLevel>().setPlayerKilled(true);
	}

	//uzywane do ochrony gracza
	public void setDead()
	{
		alive = false;
	}
}
