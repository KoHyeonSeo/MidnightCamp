using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHE_2DFrontViewCam : MonoBehaviour
{
    GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("Root");

        // 촬영 시작 위치
        transform.position = new Vector3(LHE_CalculateMaxDistance.Instance.averageX, LHE_CalculateMaxDistance.Instance.averageY, LHE_CalculateMaxDistance.Instance.maxZ + 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
