using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyBoss1 : MonoBehaviour
{
    private SCR_HPEnemyBoss s_HPEnemy;
    private SpriteRenderer s_Rendered;
    public bool b_BossActive = false;
    public Sprite s_RedSprite;
    public Sprite s_GreenSprite;
    public Sprite s_BlueSprite;    
    public int i_TypeHitDamageRepeated;

    public float f_Velocity = 1.5f;    
    public float f_MaxPosUp, f_MaxPosDown, f_MaxPosLeft, f_MaxPosRight;
    private Vector3 v_MaxPosUp, v_MaxPosDown, v_MaxPosLeft, v_MaxPosRight;
    private bool b_ChangeDirectionX = false;
    private bool b_ChangeDirectionY = false;    
    
    void Start()
    {
        i_TypeHitDamageRepeated = 0;
        InvokeRepeating("GetColorChange", .01f, 2.5f);
        s_Rendered = GetComponent<SpriteRenderer>();
        s_HPEnemy = GetComponent<SCR_HPEnemyBoss>();

        Vector3 v_Initial   = gameObject.transform.localPosition;
        v_MaxPosUp          = new Vector3(v_Initial.x, v_Initial.y + f_MaxPosUp);
        v_MaxPosDown        = new Vector3(v_Initial.x, v_Initial.y - f_MaxPosDown);
        v_MaxPosLeft        = new Vector3(v_Initial.x - f_MaxPosLeft, v_Initial.y);
        v_MaxPosRight       = new Vector3(v_Initial.x + f_MaxPosRight,v_Initial.y);        
    }
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if((f_MaxPosLeft != 0f) && (f_MaxPosRight != 0f))
        {
            this.BasicMovimentX();
        }
    }    

    private void BasicMovimentX()
    {
        if (!b_ChangeDirectionX)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, v_MaxPosLeft, f_Velocity * Time.deltaTime);
        }
        if (gameObject.transform.localPosition == v_MaxPosLeft)
        {
            b_ChangeDirectionX = true;
            Flip();
        }

        if (b_ChangeDirectionX)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, v_MaxPosRight, f_Velocity * Time.deltaTime);
        }
        if (gameObject.transform.localPosition == v_MaxPosRight)
        {
            Flip();
            b_ChangeDirectionX = false;
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
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
