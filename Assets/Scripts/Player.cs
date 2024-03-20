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
    [SerializeField]private float spd;
    [SerializeField]private float jumpForce, doubleForce;

    private bool isJumping;
    private bool doubleJump;
    private float axisX;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private void Start() 
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        Move();
        Jump();
    }

    //movimentacao do personagem para horizontal
    private void Move()
    {
        axisX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(axisX * spd,rb.velocity.y);

        if(axisX > 0)
        {
            if(!isJumping)
            {
                animator.SetInteger("transition",1);
            }
            sr.flipX = false;
        }

        if(axisX < 0)
        {
            if(!isJumping)
            {
                animator.SetInteger("transition",1);
            }
            sr.flipX = true;
        }  

        if(axisX == 0 && !isJumping)
        {
            animator.SetInteger("transition",0);
        }
    }
    //pulo do personagem
    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
            animator.SetInteger("transition",2);
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            doubleJump = true;
            isJumping = true;
            }
            else 
            {
                if(doubleJump)
                {
                animator.SetInteger("transition",2);
                rb.AddForce(new Vector2(0,doubleForce),ForceMode2D.Impulse);
                doubleJump = false;
                }
            }
        }
        // if()
        // {

        // }

    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}
