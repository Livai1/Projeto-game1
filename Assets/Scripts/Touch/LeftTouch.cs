using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LeftTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isLeft;
    private Player player;

    private float movement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isLeft)
        {
            movement -= Time.deltaTime;

            if(movement < -1f)
            {
                movement = -1f;
            }
            player.axisX = movement;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isLeft = false;
        movement = 0f;
        player.axisX = movement;
    }
}