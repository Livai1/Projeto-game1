using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private float speed;
    
    public bool isRight = false;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject);
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
}
