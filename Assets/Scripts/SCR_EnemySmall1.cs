using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemySmall1 : MonoBehaviour
{
    public float f_Velocity = 1.5f;    
    public float f_MaxPosUp, f_MaxPosDown, f_MaxPosLeft, f_MaxPosRight;
    private Vector3 v_MaxPosUp, v_MaxPosDown, v_MaxPosLeft, v_MaxPosRight;
    private bool b_ChangeDirectionX = false;
    private bool b_ChangeDirectionY = false;
    
    void Start()
    {
        Vector3 v_Initial   = gameObject.transform.localPosition;
        v_MaxPosUp          = new Vector3(v_Initial.x, v_Initial.y + f_MaxPosUp);
        v_MaxPosDown        = new Vector3(v_Initial.x, v_Initial.y - f_MaxPosDown);
        v_MaxPosLeft        = new Vector3(v_Initial.x - f_MaxPosLeft, v_Initial.y);
        v_MaxPosRight       = new Vector3(v_Initial.x + f_MaxPosRight,v_Initial.y);
    }
    
    void FixedUpdate()
    {
        if((f_MaxPosLeft != 0f) && (f_MaxPosRight != 0f))
        {
            this.BasicMovimentX();
        }

        if((f_MaxPosUp != 0f) && (f_MaxPosDown != 0f))
        {
            this.BasicMovimentY();
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

    private void BasicMovimentY()
    {
        if (!b_ChangeDirectionY)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, v_MaxPosUp, f_Velocity * Time.deltaTime);
        }
        if (gameObject.transform.localPosition == v_MaxPosUp)
        {
            b_ChangeDirectionY = true;
        }
        if (b_ChangeDirectionY)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, v_MaxPosDown, f_Velocity * Time.deltaTime);
        }
        if (gameObject.transform.localPosition == v_MaxPosDown)
        {
            b_ChangeDirectionY = false;
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
