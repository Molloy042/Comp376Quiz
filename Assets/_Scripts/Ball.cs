// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip Sound;
    public AudioSource audio;
    // Start is called before the first frame update
    public GameObject ball;
    void statr(){
        
    }
    IEnumerator  OnCollisionEnter(Collision collision)
    {
        yield return new WaitForSeconds(1);
        audio.PlayOneShot(Sound);
        yield return new WaitForSeconds(2);
        Destroy(ball);
            
    }
}
