using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class SCR_HPBaseController : MonoBehaviour
{
    public string s_TypeHitDamage;
    public int i_HPCurrent;
    public int i_HPMax;
    public float f_Untouchble = 0.1f;
    public float f_TimeDeath = 0.1f;
    public bool b_ReceiveDamage = true;    

    public UnityEvent OnDamage;
    public UnityEvent FinishDamage;
    public UnityEvent OnDeath;

    protected SpriteRenderer s_Rendered;

    protected void Start()
    {
        i_HPCurrent = i_HPMax;
        s_Rendered = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int i_PowerDamage)
    {
        if (!b_ReceiveDamage)
            return;

        b_ReceiveDamage = false;
        i_HPCurrent -= i_PowerDamage;
        OnDamage.Invoke();
        
        if(i_HPCurrent <= 0)
        {
            OnDeath.Invoke();
            Death();
            return;
        }

        StartCoroutine(BlinkSpriteHit());
    }

    public string GetHP()
    {
        return i_HPCurrent.ToString();
    }            

    IEnumerator BlinkSpriteHit()
    {
        float timer = 0;
        Color c_DefaultColor = s_Rendered.color;

        while(timer < f_Untouchble)
        {
            s_Rendered.color = Color.clear;
            yield return new WaitForSeconds(0.05f);
            s_Rendered.color = c_DefaultColor;
            yield return new WaitForSeconds(0.05f);
            timer += 0.1f;
        }

        s_Rendered.color = c_DefaultColor;
        b_ReceiveDamage = true;
        FinishDamage.Invoke();
    } 

    public abstract void Death();
    
}
