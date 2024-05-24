using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private float speed;

    private int dmg = 1;

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

    private  void OnTriggerEnter2D(Collider2D other) 
    {
         if(other.gameObject.tag == "Enemy")
         {
            other.gameObject.GetComponent<enemy>().Damage(dmg);
            Destroy(gameObject);
         }
    }
}
