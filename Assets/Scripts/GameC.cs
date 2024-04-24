using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameC : MonoBehaviour
{
   public Text HealthText;
   public static GameC Instance;

   void Awake()
   {
      Instance = this;
   }

   public void UpdateLives(int value)
   {
      HealthText.text = "x" + value.ToString();
   }
}
