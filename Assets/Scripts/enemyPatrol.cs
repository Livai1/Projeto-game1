using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{   
    [SerializeField] private float walkTime, speed;
    private float timer;
    private bool walkRight;
    private Rigidbody2D rig;

    void Start() 
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        timer+= Time.deltaTime;

        if(timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if(walkRight)
        {
            transform.eulerAngles = new Vector2(0,0);
            rig.velocity = Vector3.left * speed;
        }

        else
        {
            transform.eulerAngles = new Vector2(0,180);
            rig.velocity = Vector3.right * speed;
        }
    }
}
