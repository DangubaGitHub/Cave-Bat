using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;

    [SerializeField] GameObject yellowCounter;

    public bool menuOn;

    void Start()
    {
        TurnMenuOn();
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
        TurnMenuOff();
    }

    public void TurnMenuOn()
    {
        MenuPanel.SetActive(true);
        yellowCounter.SetActive(false);
        menuOn = true;
        Time.timeScale = 0;

    }

    public void TurnMenuOff()
    {
        MenuPanel.SetActive(false);
        yellowCounter.SetActive(true);
        menuOn = false;
        Time.timeScale = 1;
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        ScoreManager.instance.highScoreCount = 0;
        ScoreManager.instance.UpdateHighScoreCount();
    }
}
