using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timer;
    private bool WalkRight;
    [SerializeField] private float walkTime, speed;
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
            timer = 0f;
            WalkRight = !WalkRight;
        }

        if(WalkRight)
        {
            transform.eulerAngles = new Vector2(0,180);
            rig.velocity = Vector2.right * speed;
        }

        else
        {
            transform.eulerAngles = new Vector2(0,0);
            rig.velocity = Vector2.left * speed;
        }
    }
}
