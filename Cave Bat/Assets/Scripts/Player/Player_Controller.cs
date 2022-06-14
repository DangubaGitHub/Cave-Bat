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
    const string DIVE = "Player_Dive_Down";
    const string DIVE_L = "Player_Dive_Down_L";
    const string DIVE_END = "Player_Dive_Up";
    const string DIVE_END_L = "Player_Dive_Up_L";

    bool isDiving;
    bool isFlying;

    [SerializeField] float speed;
    [SerializeField] float glideSpeed;
    [SerializeField] float jump;
    int playerDirection = -1;

    Menu menu_Script;
    [SerializeField] GameObject Menu;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

        menu_Script = Menu.GetComponent<Menu>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (menu_Script.menuOn == false)
        {
            //playerRb.velocity = new Vector2(playerDirection * transform.localScale.x * speed, playerRb.velocity.y);
            playerRb.velocity = new Vector2(playerDirection * transform.localScale.x * speed, transform.localScale.y * glideSpeed);

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerDirection = -1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerDirection = 1;
            }

            if (Input.GetButtonDown("Jump") && !isDiving)
            {
                isFlying = true;
                Jump();
                //AudioManager.instance.PlaySFX(1);
            }

            else if (Input.GetButtonUp("Jump") && !isDiving)
            {
                SetGlideSpeedBack();
                isFlying = false;
                //AudioManager.instance.PlaySFX(2);
            }

            if (Input.GetButtonDown("Dive") && playerDirection == 1 && !isFlying)
            {
                isDiving = true;
                ChangeAnimationState(DIVE);
                Dive();
                //AudioManager.instance.PlaySFX(0);
            }

            else if (Input.GetButtonUp("Dive") && playerDirection == 1 && !isFlying)
            {
                ChangeAnimationState(DIVE_END);
                SetGlideSpeedBack();
                isDiving = false;
                //AudioManager.instance.PlaySFX(2);
            }

            if (Input.GetButtonDown("Dive") && playerDirection == -1 && !isFlying)
            {
                isDiving = true;
                ChangeAnimationState(DIVE_L);
                Dive();
                //AudioManager.instance.PlaySFX(0);
            }

            else if (Input.GetButtonUp("Dive") && playerDirection == -1 && !isFlying)
            {
                ChangeAnimationState(DIVE_END_L);
                SetGlideSpeedBack();
                isDiving = false;
                //AudioManager.instance.PlaySFX(2);
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
