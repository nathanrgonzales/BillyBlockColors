using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HPEnemyBasic : SCR_HPBaseController
{
    private int i_DefaultLayer;
    private AudioSource a_Audio;
    public AudioClip a_Death;    

    private void Start()
    {
        base.Start();  
        a_Audio = GetComponent<AudioSource>();      
        i_DefaultLayer = gameObject.layer;
    }

    public override void Death()
    {
        a_Audio.clip = a_Death;
        a_Audio.Play();
        StartCoroutine(TimePreLoader());
        Destroy(gameObject);
    }

    IEnumerator TimePreLoader()
    {
        yield return new WaitForSeconds(10f);
    }       

    public void SetInvencible(bool b_state)
    {
        if (b_state)
        {
            gameObject.layer = LayerMask.NameToLayer("Invencible");
        }            
        else
            gameObject.layer = i_DefaultLayer;
    }    
}
