using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyBig1 : MonoBehaviour
{
    public float f_VelocityUp = 1f;
    public float f_VelocityDown = 3f;
    public float f_MaxPosUp;
    private Vector3 v_MaxPosUp, v_MaxPosDown;
    private bool b_ChangeDirectionY = false;
    
    void Start()
    {
        Vector3 v_Initial   = gameObject.transform.localPosition;
        v_MaxPosUp          = new Vector3(v_Initial.x, v_Initial.y + f_MaxPosUp);
        v_MaxPosDown        = new Vector3(v_Initial.x, v_Initial.y);
    }
    
    void FixedUpdate()
    {
        BasicMovimentY();
    }

    private void BasicMovimentY()
    {
        if (!b_ChangeDirectionY)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, v_MaxPosUp, f_VelocityUp * Time.deltaTime);
        }
        if (gameObject.transform.localPosition == v_MaxPosUp)
        {
            b_ChangeDirectionY = true;
        }
        if (b_ChangeDirectionY)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, v_MaxPosDown, f_VelocityDown * Time.deltaTime);
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
