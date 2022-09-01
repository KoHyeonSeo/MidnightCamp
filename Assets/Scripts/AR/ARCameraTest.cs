using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraTest : MonoBehaviour
{
    public Camera arCamera;
    public GameObject root;
    public float distance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        root.transform.position = arCamera.transform.position + arCamera.transform.forward * distance;
    }
}
