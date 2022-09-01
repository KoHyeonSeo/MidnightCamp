using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleEditor : MonoBehaviour
{
    
    InputManager manager;
    GameObject objectToScale;
    [SerializeField]List<GameObject> objectToScales = new List<GameObject>();
    Vector3 surface;
    bool isClicked;
    bool oneClick;
    float oldScrollPoint;
    [SerializeField]float delayTime=1;
    Vector3 oldMousePosition;
    Vector3 toScaleVec;
    [SerializeField] float multiplier=0.1f;
    float opposite=1;
   
    float curTime;
    
    void Start()
    {
        manager = GetComponent<InputManager>();
    }

    void Update()
    {

        #region 마우스 커서가 오브젝트를 눌렀을 때 (단일 오브젝트)
        // 마우스 클릭하면 화면상의 오브젝트를 선택하는 구문
        AddObject();
        if (manager.MouseLeftClick)
        {
            // 만약 PointerBlock 이 존재한다면 editor 모드 시작


               
                
                isClicked = true;
            
            //만약 기준 벡터와 클릭한 노멀벡터의 외적값을 구할 수있다면

            curTime += Time.deltaTime;
            if (curTime > delayTime)
            {
                //꾹 누른상태에서 2초 지났을 때 스케일모드 작동
                //여기서 마우스커서값과 normal 값의 내적을 비교한다.
                FindDir(objectToScales[0].transform, surface);
                StartCoroutine(ScaleObjs());
            }
        } 
        else
        {
            StopAllCoroutines();
            objectToScales.Clear();
            curTime = 0;
            isClicked = false;
        }
        #endregion
        #region 다중 오브젝트를 눌렀을 때
       
        #endregion

        // 이전 값 업데이트
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
            opposite = 1;
            toScaleVec = Vector3.forward;
        }
        else if (CrossVec==Vector3.zero)
        {
           
            opposite = -1;
            toScaleVec = Vector3.back;
            //뒷면
        }
        else if (CrossVec == obj.up)
        {
            toScaleVec = Vector3.left;
            opposite = -1;
            //여기는 왼쪽면
        }
        else if (CrossVec == -obj.up)
        {
            toScaleVec = Vector3.right;
            opposite = 1;
            //여기는 오른쪽면
        }
        else if (CrossVec == -obj.right)
        {
            toScaleVec = Vector3.up;
            opposite = 1;
            //여기는 윗면
        }
        else if (CrossVec == obj.right)
        {
            toScaleVec = Vector3.down;
            opposite = -1;
            //여기는 아랫면
        }
    }
    void ScaleObj(Transform objectToScale)
    {
        if (manager.MouseWheelScroll > 0)
        {
            objectToScale.localScale += opposite * toScaleVec * multiplier;
            objectToScale.position += surface * (multiplier * 0.5f);
        }
        else if (manager.MouseWheelScroll < 0)
        {
            if (!(objectToScale.localScale.x <= 0.1f
                || objectToScale.localScale.y <= 0.1f
                || objectToScale.localScale.z <= 0.1f))
            {
                objectToScale.localScale -= opposite * toScaleVec * multiplier;
                objectToScale.position -= surface * (multiplier * 0.5f);
            }
            else
            { }
        }
    }
    IEnumerator ScaleObjs()
    {
        for (int i = 0; i < objectToScales.Count; i++)
        {

            if (manager.MouseWheelScroll > 0)
            {
                objectToScales[i].transform.localScale += opposite * toScaleVec * multiplier;
                objectToScales[i].transform.position += surface * (multiplier * 0.5f);
            }
            else if (manager.MouseWheelScroll < 0)
            {
                if (!(objectToScales[i].transform.localScale.x <= 0.1f
                    || objectToScales[i].transform.localScale.y <= 0.1f
                    || objectToScales[i].transform.localScale.z <= 0.1f))
                {
                    objectToScales[i].transform.localScale -= opposite * toScaleVec * multiplier;
                    objectToScales[i].transform.position -= surface * (multiplier * 0.5f);
                }
                else
                { } 
                
            }
        }
        yield return null;    
    }
    void AddObject()
    {
        //만약 ctrl 키가 눌러진 상태이면 리스트에 지속적으로 업로드 가능 
        if (manager.MouseLeftClick&&!isClicked)
        {
            objectToScales.Add(manager.PointBlock);
            //만약 중복선택했을 경우 리스트에 넣지 않는다.   
            surface = manager.ObjectHitNormal;
            isClicked = true;
        }
        if (manager.MouseLeftClick && manager.CtrlKeyDown)
        {
            //만약 중복선택했을 경우 리스트에 넣지 않는다.
            objectToScales.Add(manager.PointBlock);
            //만약 중복선택했을 경우 리스트에 넣지 않는다.   
            oneClick = true;

        }
        else
        {
            oneClick = false;
        }
        for (int i = 0; i < objectToScales.Count; i++)
        {
            if (manager.PointBlock.GetInstanceID() == objectToScales[i].GetInstanceID())
            {
                print("중복");
                //objectToScales.Remove(manager.PointBlock);
            }
            else
            {
               // objectToScales.Add(manager.PointBlock);
            }
        }


    }
}
