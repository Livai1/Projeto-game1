using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    [SerializeField] private float spd;
    [SerializeField] private float jumpForce,DoubleForce;
    private float axisX;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    //movimentacao do personagem
    private void Move()
    {
        axisX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(axisX * spd, rb.velocity.y);

        if(axisX > 0)
        {
            sr.flipX = false;
        }

        if(axisX < 0)
        {
            sr.flipX = true;
        }

    }


    private void Jump()
    {

    }

}