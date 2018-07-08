using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMouseFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
               Input.mousePosition.x,
               Input.mousePosition.y,
               0);
    }
}
