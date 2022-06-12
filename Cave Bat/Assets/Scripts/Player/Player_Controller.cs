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
    [SerializeField] float diveSpeed;
    [SerializeField] float jump;
    int playerDirection = -1;

    [SerializeField] Quaternion toAngle;
    [SerializeField] Quaternion fromAngle;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
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

            fromAngle = transform.rotation;
            toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 75f));
            
        }
        //Debug.Log(playerRb.velocity.y);
        //transform.eulerAngles = new Vector3(0, 0, playerRb.velocity.y * 5f);

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
        //playerRb.velocity = new Vector2(jump * Time.deltaTime, playerRb.velocity.x);
        playerRb.velocity = Vector2.up * jump;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        playerAnim.Play(newState);      // anim is the Animator component

        currentState = newState;
    }
}
