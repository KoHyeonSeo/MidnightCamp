using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleEditor : MonoBehaviour
{
    // Start is called before the first frame update
    InputManager manager;
    GameObject EditObject;
    bool isClicked;
    float oldScrollPoint;
    void Start()
    {
        manager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        #region 마우스 커서가 오브젝트를 눌렀을 때
        // 마우스 클릭하면 화면상의 오브젝트를 선택하는 구문
        if (Input.GetMouseButtonDown(0))
        {
            // 만약 PointerBlock 이 존재한다면 editor 모드 시작
            if (manager.PointBlock != null)
            {
                // 게임 오브젝트 선언 
                EditObject = manager.PointBlock;
                isClicked = true;
                print("111");
            }
            //만약 빈 허공을 눌렀을 경우 기존에 눌렀던 오브젝트들을 다시 초기화 한다.
            else
            {
                EditObject = null;
                isClicked = false;
            }
        }
        #endregion
        #region 오브젝트 스크롤값 변경할때 scale값  변경
        if (isClicked && manager.MouseWheelScroll != 0)
        {

            if (manager.MouseWheelScroll - oldScrollPoint >= 0)
            {

                EditObject.transform.localScale += new Vector3(0, 0.1f, 0);

            }
            else if (manager.MouseWheelScroll - oldScrollPoint <= 0)
            {
                EditObject.transform.localScale += new Vector3(0, -0.1f, 0);
            }
            #endregion
            #region 오브젝트 스케일 변경
            //마우스 커서가 오브젝트의 면을 클릭했을 때 그 면의 스케일을 변경할 수 있도록 한다.

            #endregion


        }
        //오브젝트의 정보를 가져온다.
        if (manager.PointBlock)
        {
            Debug.Log($"Position: {manager.PointBlockInformation.position}\n" +
                $"Rotation: {manager.PointBlockInformation.rotation}\n" +
                $"Scale: {manager.PointBlockInformation.scale}");
        }
        oldScrollPoint = manager.MouseWheelScroll;
    }
}
