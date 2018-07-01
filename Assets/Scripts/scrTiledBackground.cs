using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTiledBackground : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.tileMode = SpriteTileMode.Continuous;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
