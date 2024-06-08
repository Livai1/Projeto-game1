using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class enemy : MonoBehaviour
{

    [SerializeField] private float walkTime, speed;
    
    private float timer;
    private float force;

    private bool walkRight;
    private bool stomp;

    private int health = 5;
    private int dmg = 1;

    private Rigidbody2D rig2D;
    private Animator anim;

    void Start()
    {
         rig2D = GetComponent<Rigidbody2D>();
         anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= walkTime)
        {
            timer = 0f;

            walkRight = !walkRight;
        }
    }

    void FixedUpdate()
    {
        if(walkRight)
        {
            transform.eulerAngles = new Vector2(0,180);
            rig2D.velocity = Vector2.right * speed;
        }

        else 
        {
            transform.eulerAngles = new Vector2(0,0);
            rig2D.velocity = Vector2.left * speed;
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player>().Damage(dmg);
        }
    }
}
