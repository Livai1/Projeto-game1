using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    [SerializeField] private int coinValue;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameC.Instance.UpdateScore(coinValue);
            Destroy(gameObject);
        }
    }
}
