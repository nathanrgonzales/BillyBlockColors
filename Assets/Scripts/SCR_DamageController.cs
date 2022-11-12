using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DamageController : MonoBehaviour
{
    public int i_Damage;

    public string s_TypeHitDamage;

    public bool b_DestroyOnDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SCR_HPBaseController o_HPControllerOther = other.GetComponent<SCR_HPBaseController>();        
        SCR_DamageController o_DamageController = GetComponent<SCR_DamageController>();
        if((o_HPControllerOther != null) && (o_HPControllerOther.s_TypeHitDamage == o_DamageController.s_TypeHitDamage))
        {
            DoDamage(o_HPControllerOther);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SCR_HPBaseController o_HPControllerOther = other.gameObject.GetComponent<SCR_HPBaseController>();
        SCR_DamageController o_DamageController = gameObject.GetComponent<SCR_DamageController>();
        if ((o_HPControllerOther != null) && (o_HPControllerOther.s_TypeHitDamage == o_DamageController.s_TypeHitDamage))
        {
            DoDamage(o_HPControllerOther);
        }
    }

    void DoDamage(SCR_HPBaseController p_HPController)    
    {   
        p_HPController.TakeDamage(i_Damage);
        if (b_DestroyOnDamage)
            Destroy(gameObject);
    }
}
