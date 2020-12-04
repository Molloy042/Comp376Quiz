// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannoe1 : MonoBehaviour
{
    public GameObject ball;
    private float nextActionTime = 0.0f;
    public float period = 2.0f;
    public AudioClip Sound;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
        nextActionTime += period;
         Instantiate(ball, new Vector3(-6.041f,24.357f,-11.261f), transform.rotation);
         audio.PlayOneShot(Sound);
        
     }
    }
    
}
