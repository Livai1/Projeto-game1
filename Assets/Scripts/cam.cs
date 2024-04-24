using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class cam : MonoBehaviour
{
   private Transform player;
   [SerializeField] private float smooth;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   void LateUpdate()
   {
      if(player.position.x >= -3)
      {
      Vector3 following =  new Vector3(player.position.x, player.position.y, transform.position.z);
      transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
      }
   }
}
