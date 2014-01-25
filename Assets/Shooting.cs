using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public Vector3 speed;
    //public GameObject weapon;

    public List<GameObject> lista = new List<GameObject>();
    public AudioClip shotSound;
    // Use this for initialization 
    void Start()
    {
        //player = GameObject.Find("3rd Person Controller");
        //player.transform.position. 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            var b = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;

            //b.transform.Rotate(new Vector3(90, transform.rotation.eulerAngles.y, 180));
            b.rigidbody.AddForce(transform.forward * 800);

            Debug.Log("transform.forward: " + transform.forward);

            audio.PlayOneShot(shotSound);
            //audio.Play(shotSound); 

            lista.Add(b);
        }
    }
} 