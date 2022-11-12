using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HPEnemyBasic : SCR_HPBaseController
{
    private int i_DefaultLayer;        

    private void Start()
    {
        base.Start();        
        i_DefaultLayer = gameObject.layer;
    }

    public override void Death()
    {
        Destroy(gameObject);
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
