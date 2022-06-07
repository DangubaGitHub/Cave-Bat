using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int yellow;
    public int purple;

    private void Awake()
    {
        instance = this;
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
    }

    public void AddPurple()
    {
        purple++;
    }
}
