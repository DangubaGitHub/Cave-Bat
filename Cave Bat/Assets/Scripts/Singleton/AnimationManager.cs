using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    string currentState;

    const string YELLOW = "Yellow_Idle";
    const string PURPLE = "Purple_Idle";

    GameObject Player;
    GameObject Yellow;

    private void Awake()
    {
        instance = this;
        Yellow = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);      // anim is the Animator component

        currentState = newState;
    }
}
