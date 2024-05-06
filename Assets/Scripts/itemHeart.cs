using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHeart : MonoBehaviour
{

    [SerializeField] private int healthValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().IncreaseLife(healthValue);
            Destroy(gameObject);
        }
    }
}
