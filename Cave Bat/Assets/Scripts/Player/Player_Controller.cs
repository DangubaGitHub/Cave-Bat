using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    Rigidbody2D playerRb;
    SpriteRenderer playerSr;
    Animator playerAnim;

    string currentState;

    const string UP = "Player_Up";
    const string GLIDE = "Player_Glide";
    const string DIVE = "Player_Dive";

    bool isDiving;

    [SerializeField] float speed;
    [SerializeField] float glideSpeed;
    [SerializeField] float jump;
    int playerDirection = -1;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //playerRb.velocity = new Vector2(playerDirection * transform.localScale.x * speed, playerRb.velocity.y);
        playerRb.velocity = new Vector2(playerDirection * transform.localScale.x * speed, transform.localScale.y * glideSpeed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerDirection = -1;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            playerDirection = 1;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        else if (Input.GetButtonUp("Jump"))
        {
            SetGlideSpeedBack();
        }

        if (Input.GetButtonDown("Dive"))
        {
            Dive();
        }

        else if (Input.GetButtonUp("Dive"))
        {
            SetGlideSpeedBack();
        }

        if (playerRb.velocity.x < 0)
        {
            playerSr.flipX = true;
        }

        else if (playerRb.velocity.x > 0)
        {
            playerSr.flipX = false;
        }

        if (playerRb.velocity.y < 0 && !isDiving)
        {
            ChangeAnimationState(GLIDE);
        }

        else if (playerRb.velocity.y > 0)
        {
            ChangeAnimationState(UP);
        }
    }

    private void FixedUpdate()
    {

    }

    void Jump()
    {
        //playerRb.velocity = Vector2.up * jump;
        //playerRb.AddForce(transform.up * jump);
        glideSpeed = 8;

        //Invoke("SetGlideSpeedBack", .3f);
    }

    void Dive()
    {
        glideSpeed = -20;
    }

    void SetGlideSpeedBack()
    {
        glideSpeed = -3f;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        playerAnim.Play(newState);

        currentState = newState;
    }
}
