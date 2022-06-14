using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text highScoreText;

    public int highScoreCount;

    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        highScoreCount = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreCount();
    }

    void Update()
    {
        if(GameManager.instance.yellow > highScoreCount)
        {
            highScoreCount = GameManager.instance.yellow;
            PlayerPrefs.SetInt("HighScore", highScoreCount);
            PlayerPrefs.Save();
        }
        UpdateHighScoreCount();
    }

    public void UpdateHighScoreCount()
    {
        highScoreText.text = "High Score: " + highScoreCount.ToString();
    }


}
