using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleEditor : MonoBehaviour
{
    // Start is called before the first frame update
    InputManager manager;
    GameObject EditObject;
    Vector3 dir;
    Vector3 area;
    bool isClicked;
    float oldScrollPoint;
    Vector3 oldMousePosition;
    float curTime;
    void Start()
    {
        manager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        #region 마우스 커서가 오브젝트를 눌렀을 때
        // 마우스 클릭하면 화면상의 오브젝트를 선택하는 구문
        if (manager.MouseLeftClick)
        {
            // 만약 PointerBlock 이 존재한다면 editor 모드 시작

            if (!isClicked)
            {
                EditObject = manager.PointBlock;
                area = manager.ObjectHitNormal;
                isClicked = true;
            }
            // 게임 오브젝트 선언 

            curTime += Time.deltaTime;
            if (curTime > 2)
            {
                //꾹 누른상태에서 2초 지났을 때 스케일모드 작동

                //여기서 마우스커서값과 normal 값의 내적을 비교한다.
                print(manager.MouseWheelScroll);

                if (manager.MouseWheelScroll > 0)
                {
                    EditObject.transform.localScale += area*0.1f;
                    
                }
                else if (manager.MouseWheelScroll < 0)
                {
                    EditObject.transform.localScale -= area*0.1f;
                }

            }
        } 
        //만약 빈 허공을 눌렀을 경우 기존에 눌렀던 오브젝트들을 다시 초기화 한다.
        else
        {
            EditObject = null;
            curTime = 0;
            isClicked = false;
        }
        #endregion
        #region 오브젝트 스크롤값 변경할때 scale값  변경
        //if (isClicked && manager.MouseWheelScroll != 0)
        //{

        //    if (manager.MouseWheelScroll - oldScrollPoint >= 0)
        //    {

        //        EditObject.transform.localScale += new Vector3(0, 0.1f, 0);

        //    }
        //    else if (manager.MouseWheelScroll - oldScrollPoint <= 0)
        //    {
        //        EditObject.transform.localScale += new Vector3(0, -0.1f, 0);
        //    }
            #endregion
            #region 오브젝트 스케일 변경
            //마우스 커서가 오브젝트의 면을 클릭했을 때 그 면의 스케일을 변경할 수 있도록 한다.

            #endregion


        //}
       
        oldScrollPoint = manager.MouseWheelScroll;
        oldMousePosition = manager.MousePosition;
    }
}
