using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRepeatedBackground : MonoBehaviour {

    SpriteRenderer repeatSprite;
    private float spriteWidth;
    private float spriteHeight;
    Camera cam;
    private float prevViewX;
    private float prevViewY;

    void Start()
    {
        repeatSprite = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        float spriteHeight = 2f * cam.orthographicSize;
        float spriteWidth = spriteHeight * cam.aspect;

        prevViewX = cam.rect.x;
        prevViewY = cam.rect.y;
    }

    //draws the background
    void drawTiles()
    {
        transform.localScale = new Vector3(1, 1, 1);

        double width = repeatSprite.sprite.bounds.size.x;
        double height = repeatSprite.sprite.bounds.size.y;

        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        //creates new width and height scale 
        double newScaleWidth = worldScreenWidth / width; 
        double newScaleHeight = worldScreenHeight / height;

        transform.localScale.Set((float) newScaleWidth, (float) newScaleHeight, 1);
    }

    void Update()
    {
        //checks if there's a change in the camera position
        if (cam.rect.x != prevViewX || cam.rect.y != prevViewY)
        {
            //deleteOldTiles();
            drawTiles();
            prevViewX = cam.rect.x;
            prevViewY = cam.rect.y;
        }

    }
}
