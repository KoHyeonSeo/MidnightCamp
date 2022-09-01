using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleEditor : MonoBehaviour
{
    // Start is called before the first frame update
    InputManager manager;
    GameObject EditObject;
    Vector3 area;
    bool isClicked;
    float oldScrollPoint;
    Vector3 oldMousePosition;
    Vector3 toscaleVec;
    float multi=1;
   
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
            //만약 기준 벡터와 클릭한 노멀벡터의 외적값을 구할 수있다면

            curTime += Time.deltaTime;
            if (curTime > 1)
            {
                //꾹 누른상태에서 2초 지났을 때 스케일모드 작동
                //여기서 마우스커서값과 normal 값의 내적을 비교한다.
                FindDir(EditObject.transform, area);
                print(toscaleVec);
                if (manager.MouseWheelScroll > 0)
                {
                    EditObject.transform.localScale += multi * toscaleVec * 0.1f;
                    EditObject.transform.position += area * 0.05f;
                }
                else if (manager.MouseWheelScroll < 0)
                {
                    if (EditObject.transform.localScale.x <= 0.1f || EditObject.transform.localScale.y <= 0.1f || EditObject.transform.localScale.z <= 0.1f)
                    {

                    }
                    else
                    {
                        EditObject.transform.localScale -= multi * toscaleVec * 0.1f;
                        EditObject.transform.position -= area * 0.05f;
                    }
                    
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

    void FindDir(Transform obj,Vector3 normalVec)
    {
        //여기서 오브젝트의 벡터값을 판별한다.
        //목표는 오브젝트를 돌려도 그 면의 순수 벡터값을 얻게 하는 것
        Vector3 CrossVec = Vector3.Cross(obj.forward, normalVec);


        if (Vector3.Dot(obj.forward, normalVec) == 1)
        {
            print(Vector3.Dot(obj.forward, normalVec));
            print("앞");
            multi = 1;
            toscaleVec = Vector3.forward;
        }
        else if (CrossVec==Vector3.zero)
        {
            print("뒤");
            multi = -1;
            toscaleVec = Vector3.back;
            //뒷면
        }
        else if (CrossVec == obj.up)
        {
            toscaleVec = Vector3.left;
            print("왼");
            multi = -1;
            //여기는 왼쪽면
        }
        else if (CrossVec == -obj.up)
        {
            toscaleVec = Vector3.right;
            multi = 1;
            print("오");
            //여기는 오른쪽면
        }
        else if (CrossVec == -obj.right)
        {
            toscaleVec = Vector3.up;
            multi = 1;
            print("위");
            //여기는 윗면
        }
        else if (CrossVec == obj.right)
        {
            toscaleVec = Vector3.down;
            multi = -1;
            print("아래");
            //여기는 아랫면
        }


    }
}
