using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int yellow;
    public int purple;

    UIController uiControllerScript;
    public GameObject UI_Canvas;

    private void Awake()
    {
        instance = this;
        uiControllerScript = UI_Canvas.GetComponent<UIController>();
    }

    void Start()
    {
        yellow = 0;
        purple = 0;
    }

    void Update()
    {
        
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddYellow()
    {
        yellow++;
        uiControllerScript.UpdateYellowCount();
    }

    public void AddPurple()
    {
        purple++;
        uiControllerScript.UpdatePurpleCount();
    }
}
