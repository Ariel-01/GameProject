﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraFollow : MonoBehaviour
{
    const float PAN_SPEED = 10.0f;
    const float PAN_THICKNESS = 10.0f;

    public float MAX_X;
    public float MAX_Y;
    public GameObject leftLimit;
    public GameObject rightLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        
        //check to ensure the cursor hasn't went over the limit
        if (currentPos.x > rightLimit.transform.position.x) {
            currentPos.x = rightLimit.transform.position.x;
            transform.position = currentPos;
        }
        else if (currentPos.x < leftLimit.transform.position.x) {
            currentPos.x = leftLimit.transform.position.x;
            transform.position = currentPos;
        }

        Vector3 newPos = transform.position;
        if (Input.mousePosition.x <= PAN_THICKNESS)
        {
            newPos.x -= PAN_SPEED * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - PAN_THICKNESS)
        { 
            newPos.x += PAN_SPEED * Time.deltaTime;
        }
        
        newPos.x = Mathf.Clamp(newPos.x ,- MAX_X,MAX_X);
        transform.position = newPos;
        
    }
}
