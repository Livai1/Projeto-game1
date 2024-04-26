using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameC : MonoBehaviour
{
   public Text healthText;
   
   public int score;
   public Text coinText;

   public static GameC Instance;

   void Awake()
   {
      Instance = this;
   }


   public void UpdateLives(int value)
   {
      healthText.text = "x" + value.ToString();
   }

   public void UpdateCoins(int Value)
   {
      score += Value;
      coinText.text = score.ToString();
   }
}
