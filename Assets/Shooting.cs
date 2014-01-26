﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public int speed;

    public AudioClip shotSound;
    public AudioClip reloadSound;

    int numBullets;
    bool shooting; 

    // Use this for initialization 
    void Start()
    {
        numBullets = 1;
        shooting = true;  
		speed = 5000;
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shooting == true) 
        {
            var b = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity) as GameObject; 

            //b.transform.Rotate(new Vector3(90, transform.rotation.eulerAngles.y, 180)); 
            b.rigidbody.AddForce(transform.forward * speed);

            numBullets--; 

            audio.PlayOneShot(shotSound); 
        } 
        
        if (numBullets <= 0) 
        { 
            shooting = false; 
            audio.PlayOneShot(reloadSound); 
            numBullets = 1; 
            Invoke("reloadFinished", 1); 
        } 
    } 

    void reloadFinished()
    {
        shooting = true;
    }
} 