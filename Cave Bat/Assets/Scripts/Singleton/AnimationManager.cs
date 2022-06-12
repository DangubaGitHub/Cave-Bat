using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    Animator anim;

    string currentState;

    const string YELLOW = "Yellow_Idle";
    const string PURPLE = "Purple_Idle";

    public const string UP = "Player_Up";
    public const string GLIDE = "Player_Glide";
    public const string DIVE = "Player_Dive";


    GameObject Player;
    GameObject Yellow;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);      // anim is the Animator component

        currentState = newState;
    }
}
