using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHE_3DAxisRotate : MonoBehaviour
{
    float rotX;
    float rotY;
    public float leftRightSpeed = 400;
    public float upDownSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.rotation.x; // 위아래
        rotY = transform.rotation.y; // 좌우

        // 시작위치
        transform.position = new Vector3(LHE_CalculateMaxDistance.Instance.minX - 3, LHE_CalculateMaxDistance.Instance.averageY, LHE_CalculateMaxDistance.Instance.averageZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            rotX += my * upDownSpeed * Time.deltaTime;
            rotY += mx * leftRightSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(-rotX, -rotY, 0);
        }
    }
}
