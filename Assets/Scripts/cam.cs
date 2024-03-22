using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.LowLevel;
using Vector3 = UnityEngine.Vector3;

public class cam : MonoBehaviour
{
    private Transform player;
    [SerializeField]private float smooth;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() 
    {
        if(player.position.x > 0)
        {
        Vector3 following = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
    }
}
