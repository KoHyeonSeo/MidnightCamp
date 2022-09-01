using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraTest : MonoBehaviour
{
    public Camera arCamera;
    public GameObject GameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject.transform.position = arCamera.transform.position + arCamera.transform.forward * 7;
    }
}
