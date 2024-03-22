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

    [SerializeField] private GameObject bow;
    [SerializeField] private Transform firePoint;
    private bool isJumping, doubleJump;
    private bool isFire;
    private float axisX;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        BowFire();
    }

    private void FixedUpdate()
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
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if(axisX < 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0,180,0);
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
        GameObject Bow = Instantiate(bow, firePoint.position,firePoint.rotation);

        if(transform.rotation.y == 0)
        {
            Bow.GetComponent<Bow>().isRight = true;
        }

        if(transform.rotation.y == 180)
        {
            Bow.GetComponent<Bow>().isRight = false;
        }

            yield return new WaitForSeconds(0.4f);
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