// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public HealthBar healthBar;
    public Rigidbody rb;
    public int coin;
    public int RedCoin;
    public Text coinCount;
    public Text RcoinCount;
    public AudioClip CoinSound;
    public AudioClip StarSound;
    public AudioSource audio;
    public GameObject star;
    bool starsw = true;
    Vector3 starpos;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        rb = GetComponent<Rigidbody>();
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text ="Yellow Coin:" + coin;
        RcoinCount.text ="Red Coin:" + RedCoin;
    }
    IEnumerator  OnCollisionEnter(Collision collision)
    {
        starpos = GameObject.Find("Mario").transform.position;
        if ( collision.gameObject.name.Contains("Coin"))
      {
           coin++;
           if(Time.timeScale != 0f)
                audio.PlayOneShot(CoinSound);
            if(coin >=100 && RedCoin>=7 && starsw){
                starpos.y+=2;
                Instantiate(star, starpos, transform.rotation);
                starsw = false;
            }
      }
        if ( collision.gameObject.name =="RedCoi" )
      {
           RedCoin++;
           if(Time.timeScale != 0f)
                audio.PlayOneShot(CoinSound);
            if(coin >=100 && RedCoin>=7 && starsw){
                starpos.y+=2;
                Instantiate(star, starpos, transform.rotation);
                starsw = false;
            }
      }
      if ( collision.gameObject.name == "Star(Clone)")
      {
          Debug.Log("star");
          audio.PlayOneShot(StarSound);
           Destroy(GameObject.Find("Star(Clone)"));
         
      }
        if(collision.gameObject.name.Contains("FlowerPatch1")){
            yield return new WaitForSeconds(3);
            GameObject.Find("Mario").transform.position = new Vector3(-8.36f,27.881f,-26.92f);
        }
            

         if(collision.gameObject.name.Contains("FlowerPatch2")){
             yield return new WaitForSeconds(3);
             GameObject.Find("Mario").transform.position = new Vector3(-2.92f,21.99f,-26.17f);
         }
            
            
    }
    
}
