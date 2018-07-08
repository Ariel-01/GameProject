using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraFollow : MonoBehaviour
{
    Vector3 offset;
    public GameObject mouse;

    void Start()
    {
        offset = new Vector3(0f, 0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mouse.transform.position + offset;
    }
}
