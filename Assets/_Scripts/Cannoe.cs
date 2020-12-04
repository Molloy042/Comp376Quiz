// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannoe : MonoBehaviour
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
         Instantiate(ball, new Vector3(27.149f,10.568f,28.524f), transform.rotation);
         audio.PlayOneShot(Sound);
        
     }
    }
    
}
