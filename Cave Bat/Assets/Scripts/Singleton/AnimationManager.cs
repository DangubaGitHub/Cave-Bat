using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    string currentState;

    const string YELLOW = "Yellow_Idle";
    const string PURPLE = "Purple_Idle";

    private void Awake()
    {
        instance = this;
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
