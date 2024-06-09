using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isRight;
    private Player player;

    private float movement;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isRight)
        {
            movement += Time.deltaTime;

            if(movement > 1f)
            {
                movement = 1f;
            }
            player.axisX = movement;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      isRight = true; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRight = false;
        movement = 0f;
        player.axisX = movement;
    }
}