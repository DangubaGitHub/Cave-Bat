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
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Purple Pickup"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
            GameManager.instance.ReloadGame();
        }
    }
}
