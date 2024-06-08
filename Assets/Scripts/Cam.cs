using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speedCam;
    public float xOffset, yOffset;
    
    void LateUpdate()
    {
        if(target.position.x >= -7f)
        {
            Vector3 following = new Vector3(target.position.x + xOffset, target.position.y + yOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, speedCam * Time.deltaTime);
        }
    }
}
