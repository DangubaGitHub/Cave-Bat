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
    }
}
