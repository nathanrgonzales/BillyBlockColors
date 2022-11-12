using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Stage01Controller : MonoBehaviour
{
    public bool b_IsPaused;
    public bool b_IsGameOver;
    public GameObject g_HUD;
    public GameObject g_GAMEOVER;
    public GameObject g_PAUSE;

    public SCR_HPPlayer s_HPPlayer;
    
    void Start()
    {
        b_IsPaused = false;        
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            b_IsPaused = !b_IsPaused;
            Time.timeScale = b_IsPaused ? 0f : 1f;         
            g_HUD.SetActive(!b_IsPaused ? true : false);
            g_PAUSE.SetActive(b_IsPaused  ? true : false);
        }

        if(s_HPPlayer.i_HPCurrent <= 0)
        {
            g_HUD.SetActive(false);
            g_PAUSE.SetActive(false);
            g_GAMEOVER.SetActive(true);    
        }
    }
}
