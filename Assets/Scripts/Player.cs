using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float spd;
    private float axisX;
    private Rigidbody2D rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

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
            transform.eulerAngles = new Vector3(0,0,0);
            Debug.Log("andei pra direita");
        }

        if(axisX < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
            Debug.Log("andei para esquerda");
        }

    }

    
}
