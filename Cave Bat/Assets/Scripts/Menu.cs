using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject UICanvas;

    public bool menuOn;

    void Start()
    {
        UICanvas.SetActive(true);
        menuOn = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        UICanvas.SetActive(false);
        menuOn = false;
        Time.timeScale = 1;
    }
}
