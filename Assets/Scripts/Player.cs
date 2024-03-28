using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bow;
    [SerializeField] private float spd;
    [SerializeField] private float jumpForce, doubleForce;
    private float axisX;
    private bool isJumping;
    private bool doubleJump;
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
    
    private void Move()
    {
        axisX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(axisX * spd, rb.velocity.y);

        if(axisX > 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition",1);
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
                doubleJump =true;
                isJumping = true;
            }

            else
            {
                if(doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rb.AddForce(new Vector2(0,doubleForce), ForceMode2D.Impulse);
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
            anim.SetInteger("transition",3);
            GameObject Bow = Instantiate(bow,firePoint.position, firePoint.rotation);

            if(transform.rotation.y == 0)
            {
                bow.GetComponent<Bow>().isRight = true;
            }

            if(transform.rotation.y == 180)
            {
                bow.GetComponent<Bow>().isRight = false;
            }

            yield return new WaitForSeconds(0.4f);
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
