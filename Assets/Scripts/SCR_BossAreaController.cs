using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BossAreaController : MonoBehaviour
{
    public AudioSource a_Audio;
    public AudioClip a_BossMusic;
    private bool b_IsActive = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndGame()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(b_IsActive)
        {
            return;
        }
        b_IsActive = true;
        a_Audio.clip = a_BossMusic;
        a_Audio.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(b_IsActive)
        {
            return;
        }        
        b_IsActive = true;
        a_Audio.clip = a_BossMusic;
        a_Audio.Play();
    }  

}
