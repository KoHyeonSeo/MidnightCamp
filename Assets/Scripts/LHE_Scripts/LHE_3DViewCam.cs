using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [���� �ϰ� ���� ���(ideal)]
// ���Ӻ� �󿡼� ray�� ���� ���� ����� �κ�(=���� Ƣ��� �κ�)�� �������� 5��ŭ ������ ���� ī�޶� ��ġ�ϰ� �ϰ�ʹ�

// [���� ������ ���]
// (0, 0, 10)�� ��ġ�� ī�޶󿡼� ray�� ���� ��� �κа� �Ÿ��� 5��ŭ ������ ���� ī�޶� ��ġ�ϰ� �ϰ�ʹ�
// �Ѱ���: ������Ʈ�� ���� Ƣ��� �κ��� ray�� ���� �κ��� �ƴ� ��� ī�޶� ����� �ʴ� �κ� �߻� ����
//       : ���� ������ ������ ������Ʈ���� Object��� �̸��� �� ������Ʈ�� ���� �ؾ� �� 
//       : ���� ������ ������ ������Ʈ���� �߽����� �ִ��� (0, 0, 0)�� ������ �����Ǿ�� ��(�ּ� 3DScene���� �Ѿ�ö����̶�)

public class LHE_3DViewCam : MonoBehaviour
{
    // ī�޶� ���� ��ġ
    Vector3 newCamPos;

    // Object: ���ӿ�����Ʈ, ȸ����
    //GameObject myObject;
    // �θ������Ʈ�� Root ã��
    GameObject root;
    float rotX;
    float rotY;
    public float leftRightSpeed = 400;
    public float upDownSpeed = 200;

    // ���콺 ����
    float wheelValue = 0;
    // ��ũ�� Ȯ�� ����
    public float zoomMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        // �Կ� ����� "Object" ã��
        //myObject = GameObject.Find("Object");
        root = GameObject.Find("Root");

        // �Կ� ���� ��ġ
        transform.position = new Vector3(LHE_CalculateMaxDistance.Instance.averageX, LHE_CalculateMaxDistance.Instance.averageY, LHE_CalculateMaxDistance.Instance.maxZ + 5);

        // ������Ʈ�� ȸ����
        rotX = root.transform.rotation.x; // ���Ʒ�
        rotY = root.transform.rotation.y; // �¿�
    }

    // Update is called once per frame
    void Update()
    {
        //// [1. �ʱ� ���� ��ġ]
        //// forward �������� ray�� ���
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hitinfo;

        //// hitpoint���� ��(ī�޶�)�� -forward �������� 5��ŭ ������ ������ ���Ѵ�
        //if(Physics.Raycast(ray, out hitinfo))
        //{
        //    newCamPos = hitinfo.point + new Vector3(0, 0, 5);
        //}

        //// �ش� �������� Lerp�Ѵ�
        //transform.position = Vector3.Lerp(transform.position, newCamPos, 0.5f);


        // [2. ���콺 �����ʹ�ư ���� ������ ��, ���콺 �¿�, ���� �����ӿ� ���� ������Ʈ ȸ��(����Ƽ�� �ִϸ��̼� ȸ���� ���� ���·�, ����ȸ�� ���� ���������� clamp)]
        if (Input.GetButton("Fire2"))
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            rotX += my * upDownSpeed * Time.deltaTime;
            rotY += mx * leftRightSpeed * Time.deltaTime;
            root.transform.eulerAngles = new Vector3(-rotX, -rotY, 0);
        }


        // [3. ��ũ�� �ϸ� Ȯ��/��� & (Ȥ�� �ʿ��ϴٸ�)(ī�޶� near �� �����ؼ� ���ε� �� �� �ֵ���)]
        wheelValue = Input.GetAxis("Mouse ScrollWheel");
        transform.position -= new Vector3(0, 0, zoomMultiplier * wheelValue);
        // Ȯ�� �Ѱ��� -> �� �ȵǳ�,, ���콺 �ӵ��� ������ �ӵ����� ���� �׷���..? �ϴ� ���߿�,,,,
        //float distance = Vector3.Distance(transform.position, hitinfo.point);
        //if(distance > 3)
        //{
        //}
        //print("distance " + distance);


        // [4. ������ ���� Near�� �����ؼ� ���θ� �鿩�� �� �� �ְ�]
        // �ڵ�� ã�Ҵµ� ������ ������ ���� �ǹ� �ִ� ����̴ϱ� �ƿ� �ν����Ϳ��� Near���� �� ũ��(ex. 1����) ���ָ� �ȵǳ�??
        //this.GetComponent<Camera>().nearClipPlane
    }
}
