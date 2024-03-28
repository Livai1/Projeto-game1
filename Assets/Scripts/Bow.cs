using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public bool isRight;
    private Rigidbody2D rig;
    [SerializeField] private float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject,2f);
    }

    void FixedUpdate()
    {

        if(isRight)
        {
            rig.velocity = Vector3.right * speed;

        }

        else
        {
            rig.velocity = Vector3.left * speed;
        }
    }
}
