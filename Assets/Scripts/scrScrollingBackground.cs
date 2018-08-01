using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrScrollingBackground : MonoBehaviour {
    const float RATE = 10;
    
    // Update is called once per frame
	void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x;

        mat.mainTextureOffset = offset;
	}
}
