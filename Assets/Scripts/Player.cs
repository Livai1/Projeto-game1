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
    private float jumpForce;
    private bool isJumping;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse); 
        }
    }

}