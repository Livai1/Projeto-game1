using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Rigidbody2D rig;
    public bool isRight;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
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

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
