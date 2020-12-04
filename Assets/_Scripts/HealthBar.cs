// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public float maxHealth;
	public float current;
	public Image fill;

	public void SetMaxHealth(int health)
	{
		maxHealth = health*1.0f;
	}

	public void SetHealth(int health)
	{
		slider.value = health;
	}
	void Update(){
		slider.value = current;
	}

	
}
