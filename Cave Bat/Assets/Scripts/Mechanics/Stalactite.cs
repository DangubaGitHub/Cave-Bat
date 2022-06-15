using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    Rigidbody2D Rb2d;

    

    private void Awake()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Rb2d.gravityScale = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Rb2d.gravityScale = 8;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
