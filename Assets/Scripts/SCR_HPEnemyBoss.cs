using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HPEnemyBoss : SCR_HPBaseController
{
    public SCR_BossAreaController s_BossArea;
    private int i_DefaultLayer;
    private void Start()
    {
        base.Start();
        i_DefaultLayer = gameObject.layer;
    }

    public override void Death()
    {
        s_BossArea.EndGame();
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
