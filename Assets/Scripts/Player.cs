using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firePoint;    

    public GameObject bow;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce, doubleForce;
    public float axisX;
    public bool isMobile;
    public bool touchJump;
    public bool touchFire;

    private bool isJumping, doubleJump;
    private bool isFire;

    private int health = 5;
    
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameC.Instance.UpdateLives(health);
    }

    void Update()
    {
        Jump();
        BowFire();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!isMobile)
        {
            axisX = Input.GetAxis("Horizontal");
        }

        rb.velocity = new Vector2(axisX * speed, rb.velocity.y);

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
       if(Input.GetButtonDown("Jump") || touchJump)
       {
            if(!isJumping)
            {
                anim.SetInteger("transition", 2);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
                touchJump = false;
       } 
    }

    private void BowFire()
    {
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        if(Input.GetKeyDown(KeyCode.F) || touchFire)
        {
            touchFire = false;
            isFire = true;
            anim.SetInteger("transition", 3);
            GameObject Bow = Instantiate(bow, firePoint.position, firePoint.rotation);

            if(transform.rotation.y == 0)
            {
                Bow.GetComponent<Bow>().isRight = true;
            }

            if(transform.rotation.y == 180)
            {
                Bow.GetComponent<Bow>().isRight = false;
            }

            yield return new WaitForSeconds(0.04f);
            isFire = false;
            anim.SetInteger("transition", 0);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");
        GameC.Instance.UpdateLives(health);

        if(transform.rotation.y == 0)
        {
            transform.position += new Vector3(-0.15f,0,0);
        }

        if(transform.rotation.y == 180)
        {
            transform.position += new Vector3(0.15f,0,0);
        }
        
        if(health <= 0)
        {
            GameC.Instance.GameOver();
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameC.Instance.UpdateLives(health);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 3)
        {
            isJumping = false;
        }

        if(coll.gameObject.layer == 6)
        {
            GameC.Instance.GameOver();
        }
    }
}