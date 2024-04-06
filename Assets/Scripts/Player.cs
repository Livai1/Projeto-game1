using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private float jumpForce, doubleForce;
    private float axisX;
    private bool isJumping, doubleJump;
    private bool isFire;
    private Rigidbody2D rb;
    private Animator anim;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    void Move()
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
            Debug.Log("andei pra direita");
        }

        if(axisX < 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector3(0,180,0);
            Debug.Log("andei para esquerda");
        }

        if(axisX == 0 && !isJumping)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
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
        }
    }

    void BowFire()
    {
        StartCoroutine("Fire");
    } 

    IEnumerator Fire()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {   isFire = true;
            anim.SetInteger("transition", 3);


            yield return  new WaitForSeconds(0.04f);
            isFire = false;
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
