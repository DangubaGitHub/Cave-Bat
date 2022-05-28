using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    Rigidbody2D playerRb;

    [SerializeField] float speed;
    [SerializeField] float jump;
    int playerDirection = -1;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //playerRb.velocity = Vector2.left * speed;
        
    }

    void Update()
    {
        playerRb.velocity = new Vector2(playerDirection * transform.localScale.x * speed, playerRb.velocity.y);

        if (Input.GetKeyDown(KeyCode.A))
        {
            //speed = speed;
            playerDirection = -1;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            //speed = -speed;
            playerDirection = 1;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {

    }

    void Jump()
    {
        //playerRb.velocity = new Vector2(jump * Time.deltaTime, playerRb.velocity.x);
        playerRb.velocity = Vector2.up * jump;
    }
}
