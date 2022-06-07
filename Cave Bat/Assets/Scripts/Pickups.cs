using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] bool isyellow;
    [SerializeField] bool ispurple;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (isyellow)
            {
                GameManager.instance.yellow++;
                Destroy(gameObject);
            }
        }

        if(other.CompareTag("Player"))
        {
            if(ispurple)
            {
                GameManager.instance.purple++;
                Destroy(gameObject);
            }
        }
    }
}
