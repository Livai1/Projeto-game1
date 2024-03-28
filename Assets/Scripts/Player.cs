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
    [SerializeField] private float jumpForce, doubleForce;
    private bool isJumping;
    private bool doubleJump;
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
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        axisX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(axisX * spd, rb.position.y);
        
        if(axisX > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if(axisX < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    private void Jump()
    {
       if(Input.GetButtonDown("Jump"))
       {
        if(!isJumping)
        {        
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
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