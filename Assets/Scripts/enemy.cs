using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timer;
    private bool WalkRight;
    [SerializeField] private float walkTime, speed;
    [SerializeField] private float health;
    private Rigidbody2D rig;
    private Animator anim;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //timer para o inimigo se movimentar
        timer+= Time.deltaTime;

        if(timer >= walkTime)
        {
            timer = 0f;
            WalkRight = !WalkRight;
        }

        //faz o inimigo andar para o lado direito
        if(WalkRight)
        {
            transform.eulerAngles = new Vector2(0,180);
            rig.velocity = Vector2.right * speed;
        }
        //anda pro lado esquerdo
        else
        {
            transform.eulerAngles = new Vector2(0,0);
            rig.velocity = Vector2.left * speed;
        }
    }

    public void Damage(int dmg)
    {
        //animacao e perda de vida do inimigo
        health -= dmg;
        anim.SetTrigger("hit");

        if(health <= 0)
        {
            //destroi o inimigo
            Destroy(gameObject);
        }
    }
}
