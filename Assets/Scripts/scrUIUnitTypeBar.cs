using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrUIUnitTypeBar : MonoBehaviour {

    private int imageIndex = 0;
    private bool canMove = true;
    private float timer; 

    public Sprite[] imageArray = new Sprite[3];
    const float DELAY = 0.25f;

    // Use this for initialization
    void Start () {
        timer = DELAY;
    }
	
	// Update is called once per frame
	void Update ()
    { 
        float checkInpt = Input.GetAxis("Submit");
        if (!canMove)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canMove = true;
                timer = DELAY;
            }
        }

        if (checkInpt == 1 && canMove)
        {
            canMove = false;
            if (imageIndex < (imageArray.Length - 1))
            {
                imageIndex++;
            }
            else
            {
                imageIndex = 0;
            }
            GetComponent<Image>().sprite = imageArray[imageIndex];
        }
        else if(checkInpt == -1 && canMove)
        {
            canMove = false;    
            if (imageIndex > 0)
            {
                imageIndex--;
            }
            else
            {
                imageIndex = (imageArray.Length - 1);
            }
            GetComponent<Image>().sprite = imageArray[imageIndex];
        }
    }
}
