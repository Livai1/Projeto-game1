using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHeart : MonoBehaviour
{
    [SerializeField] private int hearthValue;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player>().IncreaseLife(hearthValue);
            Destroy(gameObject);
        }
    }
   
}
