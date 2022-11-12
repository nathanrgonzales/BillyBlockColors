using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerController : MonoBehaviour
{    
    public float f_Speed = 5f;    
    public float f_MaxSpeed = 8f;    
    public float f_JumpForce = 100f;    
    public int i_direction;
    private int i_TypeShoot; /*0 = R; 1 = G; 2 = B*/
    private AudioSource a_Audio;
    public AudioClip a_Jump;
    public bool b_IsGrounded;
    Rigidbody2D r_RigiBody2D;
    Vector2 v_Direction;
    

    void Start()
    {
        i_TypeShoot = 0;
        i_direction = 1;
        r_RigiBody2D = GetComponent<Rigidbody2D>();
        a_Audio = GetComponent<AudioSource>();
        v_Direction = Vector2.right;        
        GetDirection();
    }
    
    void Update()
    {
        v_Direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        if((Input.GetButtonDown("Jump")) && (b_IsGrounded))
        {
            a_Audio.clip = a_Jump;
            a_Audio.Play();
            r_RigiBody2D.AddForce(Vector2.up * f_JumpForce, ForceMode2D.Impulse);
            b_IsGrounded = false;
        }
        
        if(Input.GetButtonDown("ChangeL"))
        {
            i_TypeShoot--;
            i_TypeShoot = i_TypeShoot < 0 ? 2 : i_TypeShoot;
        }
        
        if(Input.GetButtonDown("ChangeR"))
        {
            i_TypeShoot++;
            i_TypeShoot = i_TypeShoot > 2 ? 0 : i_TypeShoot;
        }        

        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            i_TypeShoot++;
            i_TypeShoot = i_TypeShoot > 2 ? 0 : i_TypeShoot;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            i_TypeShoot--;
            i_TypeShoot = i_TypeShoot < 0 ? 2 : i_TypeShoot;
        }        
    }

    void FixedUpdate()
    {
        r_RigiBody2D.AddForce(v_Direction * f_Speed, ForceMode2D.Impulse);
        GetDirection();
        if((Mathf.Abs(r_RigiBody2D.velocity.x) > 0.5f) && (v_Direction.x == 0f) && (b_IsGrounded))
        {
            r_RigiBody2D.AddForce(new Vector2(-r_RigiBody2D.velocity.x, 0f), ForceMode2D.Impulse);
        }
        
        if(r_RigiBody2D.velocity.x > f_MaxSpeed)
        {
            r_RigiBody2D.velocity = new Vector2(f_MaxSpeed, r_RigiBody2D.velocity.y);
        }

        if(r_RigiBody2D.velocity.x < -f_MaxSpeed)
        {
            r_RigiBody2D.velocity = new Vector2(-f_MaxSpeed, r_RigiBody2D.velocity.y);
        }                

        if(v_Direction.x != 0)
        {
            if(v_Direction.x > 0 && transform.localScale.x < 0)
            {
                Flip();
            }
            if(v_Direction.x < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
        }
    }

    public int GetTypeShoot()
    {
        if(i_TypeShoot < 0)
            i_TypeShoot = 0;
        if(i_TypeShoot > 2)
            i_TypeShoot = 2;
        return i_TypeShoot;
    }

    void GetDirection()
    {
        if(v_Direction.x != 0)
        {
            if(v_Direction.x > 0 && transform.localScale.x < 0)
            {
                i_direction = 1;
            }
            if(v_Direction.x < 0 && transform.localScale.x > 0)
            {
                i_direction = -1;
            }            
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
        GetDirection();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        b_IsGrounded = true;    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        b_IsGrounded = false;
    }
    
}
