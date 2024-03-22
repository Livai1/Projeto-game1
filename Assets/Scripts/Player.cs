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
    [SerializeField] private float jumpForce,doubleForce;

    private bool isJumping, doubleJump;
    private bool isFire;
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
        Jump();
        BowFire();
    }

    //movimentacao do personagem
    private void Move()
    {
        axisX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(axisX * spd, rb.velocity.y);

        if(axisX > 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            sr.flipX = false;
        }

        if(axisX < 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            sr.flipX = true;
        }

        if(axisX == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition", 0);
        }
    }


    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 2);
                rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }

            else
            {
                if(doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rb.AddForce(new Vector2(0, doubleForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    private void BowFire()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {   
        if(Input.GetKeyDown(KeyCode.F))
        {
        isFire = true;
        anim.SetInteger("transition", 3);
        yield return new WaitForSeconds(1f);
        anim.SetInteger("transition", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}