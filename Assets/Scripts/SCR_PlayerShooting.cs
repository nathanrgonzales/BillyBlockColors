using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerShooting : MonoBehaviour
{    
	public Transform t_PlayerAim;    
	public Rigidbody2D r_RShoot;
    public Rigidbody2D r_GShoot;
    public Rigidbody2D r_BShoot;
    public SCR_PlayerController s_PlayerController;
    private AudioSource a_Audio;
    public AudioClip a_Shoot;

    public float f_ShootVelocity = 14f;
    public float f_ShootRate = 0.2f;    
    public float f_ShootNext = 0f;

    void Start()
    {
        a_Audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }        
    }

    void Shoot()
    {
        if(Time.time < f_ShootNext)
        {
            return;
        }

        f_ShootNext = Time.time + f_ShootRate;
        Rigidbody2D newShoot;
        switch (s_PlayerController.GetTypeShoot())        
        {
            case  0: newShoot = Instantiate(r_RShoot, t_PlayerAim.position, Quaternion.identity); break;
            case  1: newShoot = Instantiate(r_GShoot, t_PlayerAim.position, Quaternion.identity); break;
            case  2: newShoot = Instantiate(r_BShoot, t_PlayerAim.position, Quaternion.identity); break;
            default: newShoot = Instantiate(r_RShoot, t_PlayerAim.position, Quaternion.identity); break;
        } 
        a_Audio.clip = a_Shoot;
        a_Audio.Play();
        newShoot.velocity = Vector2.right * f_ShootVelocity * s_PlayerController.i_direction; 
    }
}
