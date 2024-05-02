using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float walkTime;
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
            timer= 0f;

            walkRight = !walkRight;

        }

        if(walkRight)
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
