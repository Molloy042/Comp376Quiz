// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("BobombBattlefield");
    } 
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
