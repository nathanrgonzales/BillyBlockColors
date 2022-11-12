using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyBoss1 : MonoBehaviour
{
    private SCR_HPEnemyBasic s_HPEnemy;
    private SpriteRenderer s_Rendered;
    public bool b_BossActive = false;
    public Sprite s_RedSprite;
    public Sprite s_GreenSprite;
    public Sprite s_BlueSprite;    
    public int i_TypeHitDamageRepeated;
    
    void Start()
    {
        i_TypeHitDamageRepeated = 0;
        InvokeRepeating("GetColorChange", .01f, 2.5f);
        s_Rendered = GetComponent<SpriteRenderer>();
        s_HPEnemy = GetComponent<SCR_HPEnemyBasic>();
    }
    
    void Update()
    {
        
    }

    void GetColorChange()
    {
        bool b_NeedRepeat = true;
        int i_count;

        do
        {
            i_count = Random.Range(0, 2);
            
            if(i_TypeHitDamageRepeated < 1)
            {
                b_NeedRepeat = false;
            }
            else
            {
                switch (i_count)
                { 
                    case 0:
                        if(s_HPEnemy.s_TypeHitDamage != "red")
                        {
                            b_NeedRepeat = false;
                        }
                        break;

                    case 1:
                        if(s_HPEnemy.s_TypeHitDamage != "green")
                        {
                            b_NeedRepeat = false;
                        }
                        break;

                    case 2:
                        if(s_HPEnemy.s_TypeHitDamage != "blue")
                        {
                            b_NeedRepeat = false;
                        }
                        break;
                }
            }

        } while (b_NeedRepeat);

        switch (i_count)
        {  
            case 0:
                if(s_HPEnemy.s_TypeHitDamage == "red")
                {
                    i_TypeHitDamageRepeated++;
                }
                else
                {
                    s_Rendered.sprite = s_RedSprite; 
                    s_HPEnemy.s_TypeHitDamage = "red";
                    i_TypeHitDamageRepeated = 0;
                }
                break;
            
            case 1:
                if(s_HPEnemy.s_TypeHitDamage == "green")
                {
                    i_TypeHitDamageRepeated++;
                }
                else
                {
                    s_Rendered.sprite = s_GreenSprite;  
                    s_HPEnemy.s_TypeHitDamage = "green";
                    i_TypeHitDamageRepeated = 0;
                }
                break;
            
            case 2:
                if(s_HPEnemy.s_TypeHitDamage == "blue")
                {
                    i_TypeHitDamageRepeated++;
                }
                else
                {
                    s_Rendered.sprite = s_BlueSprite;
                    s_HPEnemy.s_TypeHitDamage = "blue";
                    i_TypeHitDamageRepeated = 0;
                }
                break;
        }

    }
}
