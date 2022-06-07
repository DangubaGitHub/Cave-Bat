using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text yellow;
    public Text purple;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateYellowCount()
    {
        yellow.text = GameManager.instance.yellow.ToString();
    }

    public void UpdatePurpleCount()
    {
        purple.text = GameManager.instance.purple.ToString();
    }
}
