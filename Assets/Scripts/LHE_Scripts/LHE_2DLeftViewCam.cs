using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHE_2DLeftViewCam : MonoBehaviour
{
    GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("Root");

        // �Կ� ���� ��ġ
        transform.position = new Vector3(LHE_CalculateMaxDistance.Instance.minX - 5, LHE_CalculateMaxDistance.Instance.averageY, LHE_CalculateMaxDistance.Instance.averageZ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
