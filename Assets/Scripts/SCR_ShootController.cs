using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ShootController : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 8);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }    
}
