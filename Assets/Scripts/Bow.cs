using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private  int damage;

    public bool isRight; 

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.5f);
    }
    void FixedUpdate()
    {
        if(isRight)
        {
            rig.velocity = Vector2.right * speed; 
        }

        else
        {
            rig.velocity = Vector2.left * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
    
}
