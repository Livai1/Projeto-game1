using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameC : MonoBehaviour
{
    public Text healthText;
    
    public static GameC instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void updateLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }
}
