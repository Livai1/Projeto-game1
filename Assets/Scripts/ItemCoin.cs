using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    [SerializeField] private int coinValue;

    public void  OnTriggerEnter2D(Collider2D coll) 
    {
        if(coll.gameObject.tag == "Player")
        {
            GameC.Instance.UpdateCoins(coinValue);
            Destroy(gameObject);
        }
    }
   
}
