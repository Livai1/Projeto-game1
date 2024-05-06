using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    public int scoreValue;
    
   private void OnTriggerEnter2D(Collider2D collider)
   {
        if(collider.gameObject.tag == "Player")
        {
            GameC.Instance.UpdateScore(scoreValue);
            Destroy(gameObject);
        }
   }
}
