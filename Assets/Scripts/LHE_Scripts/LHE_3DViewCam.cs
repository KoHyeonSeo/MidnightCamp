using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [원래 하고 싶은 기능(ideal)]
// 게임뷰 상에서 ray를 쏴서 가장 가까운 부분(=가장 튀어나온 부분)을 기준으로 5만큼 떨어진 곳에 카메라를 위치하게 하고싶다

// [실제 구현한 기능]
// (0, 0, 10)에 위치한 카메라에서 ray를 쏴서 닿는 부분과 거리가 5만큼 떨어진 곳에 카메라를 위치하게 하고싶다
// 한계점: 오브젝트의 가장 튀어나온 부분이 ray가 닿은 부분이 아닌 경우 카메라에 담기지 않는 부분 발생 가능
//       : 제작 씬에서 생성한 오브젝트들이 Object라는 이름의 빈 오브젝트에 담기게 해야 함 
//       : 제작 씬에서 생성한 오브젝트들의 중심점이 최대한 (0, 0, 0)에 오도록 조정되어야 함(최소 3DScene으로 넘어올때만이라도)

public class LHE_3DViewCam : MonoBehaviour
{
    // 카메라 도달 위치
    Vector3 newCamPos;

    // Object: 게임오브젝트, 회전값
    //GameObject myObject;
    // 부모오브젝트인 Root 찾기
    GameObject root;
    float rotX;
    float rotY;
    public float leftRightSpeed = 400;
    public float upDownSpeed = 200;

    // 마우스 관련
    float wheelValue = 0;
    // 스크롤 확대 배율
    public float zoomMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        // 촬영 대상인 "Object" 찾기
        //myObject = GameObject.Find("Object");
        root = GameObject.Find("Root");

        // 촬영 시작 위치
        transform.position = new Vector3(LHE_CalculateMaxDistance.Instance.averageX, LHE_CalculateMaxDistance.Instance.averageY, LHE_CalculateMaxDistance.Instance.maxZ + 5);

        // 오브젝트의 회전값
        rotX = root.transform.rotation.x; // 위아래
        rotY = root.transform.rotation.y; // 좌우
    }

    // Update is called once per frame
    void Update()
    {
        //// [1. 초기 시작 위치]
        //// forward 방향으로 ray를 쏜다
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hitinfo;

        //// hitpoint에서 나(카메라)의 -forward 방향으로 5만큼 떨어진 지점을 구한다
        //if(Physics.Raycast(ray, out hitinfo))
        //{
        //    newCamPos = hitinfo.point + new Vector3(0, 0, 5);
        //}

        //// 해당 지점으로 Lerp한다
        //transform.position = Vector3.Lerp(transform.position, newCamPos, 0.5f);


        // [2. 마우스 오른쪽버튼 누른 상태일 때, 마우스 좌우, 상하 움직임에 따라 오브젝트 회전(유니티의 애니메이션 회전과 같은 형태로, 상하회전 역시 마찬가지고 clamp)]
        if (Input.GetButton("Fire2"))
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            rotX += my * upDownSpeed * Time.deltaTime;
            rotY += mx * leftRightSpeed * Time.deltaTime;
            root.transform.eulerAngles = new Vector3(-rotX, -rotY, 0);
        }


        // [3. 스크롤 하면 확대/축소 & (혹시 필요하다면)(카메라 near 값 조절해서 내부도 볼 수 있도록)]
        wheelValue = Input.GetAxis("Mouse ScrollWheel");
        transform.position -= new Vector3(0, 0, zoomMultiplier * wheelValue);
        // 확대 한계점 -> 잘 안되네,, 마우스 속도가 프레임 속도보다 빨라서 그런듯..? 일단 나중에,,,,
        //float distance = Vector3.Distance(transform.position, hitinfo.point);
        //if(distance > 3)
        //{
        //}
        //print("distance " + distance);


        // [4. 가까이 가면 Near값 조절해서 내부를 들여다 볼 수 있게]
        // 코드는 찾았는데 어차피 가까이 가서 의미 있는 기능이니까 아예 인스펙터에서 Near값을 좀 크게(ex. 1정도) 해주면 안되나??
        //this.GetComponent<Camera>().nearClipPlane
    }
}
