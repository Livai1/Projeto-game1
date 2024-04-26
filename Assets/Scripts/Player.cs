using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bow;

    [SerializeField] private int health;
    

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

        GameC.Instance.UpdateLives(health);
    }

    void Update()
    {
        BowFire();
        Jump();
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

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 2);
                rb.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
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
        {
            isFire = true;
            anim.SetInteger("transition", 3);
            GameObject Bow = Instantiate(bow, firePoint.position, firePoint.rotation);

            if(transform.rotation.y == 0)
            {
                Bow.GetComponent<Bow>().isRight = true;
            }

            if(transform.rotation.y == 180)
            {
                Bow.GetComponent<Bow>().isRight = true;
            }

            yield return new WaitForSeconds(0.04f);
            isFire = false;
            anim.SetInteger("transition", 0);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameC.Instance.UpdateLives(health);
        anim.SetTrigger("hit");

        if(transform.rotation.y == 0)
        {
           transform.position += new Vector3(-0.5f,0,0);
        }

        if(transform.rotation.y == 180)
        {
            transform.position += new Vector3(0.5f,0,0);
        }
    
        if(health < 0)
        {
            //GameOver

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
    }
}
