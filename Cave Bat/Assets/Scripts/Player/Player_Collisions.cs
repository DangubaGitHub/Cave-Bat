using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collisions : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Yellow Pickup"))
        {
            GameManager.instance.AddYellow();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Purple Pickup"))
        {
            GameManager.instance.AddPurple();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            GameManager.instance.ReloadGame();
        }
    }
}
