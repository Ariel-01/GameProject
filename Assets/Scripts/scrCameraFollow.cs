﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraFollow : MonoBehaviour
{
    const float PAN_SPEED = 10.0;
    const float PAN_THICKNESS = 10.0f;
    public float MAX_X;
    public float MAX_Y;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        
        if(Input.mousePosition.y <= PAN_THICKNESS)
        {
            newPos.y-= PAN_SPEED * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - PAN_THICKNESS )
        {
            newPos.y += PAN_SPEED * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width + PAN_THICKNESS)
        {
            newPos.x += PAN_SPEED * Time.deltaTime;
        }
        if (Input.mousePosition.x <= PAN_THICKNESS)
        {
            newPos.x -= PAN_SPEED * Time.deltaTime;
        }

        newPos.x = Mathf.Clamp(newPos.x ,- MAX_X,MAX_X);
        newPos.y = Mathf.Clamp(newPos.y, -MAX_Y, MAX_Y);
        transform.position = newPos;
        
    }
}
