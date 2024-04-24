using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;

    [SerializeField] private float speed;
    [SerializeField] private float walkTime;
    private float timer;

    private Rigidbody2D rig;
    private Animator anim;
    
    private bool walkRight;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= walkTime)
        {
            timer = 0;

            walkRight = !walkRight;
        }
    }

    void FixedUpdate()
    {
        if(walkRight)
        {
            transform.eulerAngles = new Vector2(0,180);
            rig.velocity = Vector2.right * speed;
        }

        else 
        {
            transform.eulerAngles = new Vector2(0,0);
            rig.velocity = Vector2.left * speed;
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        if(health < 0)
        {
            Destroy(gameObject);
        }
    } 

    void OnCollisionEnter2D(Collision2D coll)
    {
         if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player>().Damage(damage);
        }   
    }
}
