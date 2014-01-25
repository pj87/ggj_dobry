using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class CreateMap : MonoBehaviour {

    public Transform brick;
    public Transform player;
    //To jest caly murek w 1 miejscu. CYA!
    List<Transform> lista = new List<Transform>(); 

	// Use this for initialization
	void Start () {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                var tmp = Instantiate(brick, new Vector3(x, 0, y), Quaternion.identity) as Transform;
                lista.Add(tmp);
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
