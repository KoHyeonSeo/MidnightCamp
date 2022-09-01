using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleEditor : MonoBehaviour
{
    
    InputManager manager;
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

        #region ���콺 Ŀ���� ������Ʈ�� ������ �� (���� ������Ʈ)
        // ���콺 Ŭ���ϸ� ȭ����� ������Ʈ�� �����ϴ� ����

        if (!manager.SelectObject&&manager.MouseLeftClick)
        {
            // ���� PointerBlock �� �����Ѵٸ� editor ��� ����
            if (!isClicked)
            {
                surface = manager.ObjectHitNormal;
                isClicked = true;
            }
            
            //���� ���� ���Ϳ� Ŭ���� ��ֺ����� �������� ���� ���ִٸ�

            curTime += Time.deltaTime;
            if (curTime > delayTime)
            {
                //�� �������¿��� 2�� ������ �� �����ϸ�� �۵�
                //���⼭ ���콺Ŀ������ normal ���� ������ ���Ѵ�.
                FindDir(manager.list[0].transform, surface);
                StartCoroutine(ScaleObjs());
            }
        } 
        else
        {
            StopAllCoroutines();
            curTime = 0;
            isClicked = false;
        }
        #endregion
        #region ���� ������Ʈ�� ������ ��
       
        #endregion

        // ���� �� ������Ʈ
        oldScrollPoint = manager.MouseWheelScroll;
        oldMousePosition = manager.MousePosition;
    }

    void FindDir(Transform obj,Vector3 normalVec)
    {
        //���⼭ ������Ʈ�� ���Ͱ��� �Ǻ��Ѵ�.
        //��ǥ�� ������Ʈ�� ������ �� ���� ���� ���Ͱ��� ��� �ϴ� ��
        Vector3 CrossVec = Vector3.Cross(obj.forward, normalVec);


        if (Vector3.Dot(obj.forward, normalVec) == 1)
        {
            print(Vector3.Dot(obj.forward, normalVec));
            print("��");
            opposite = 1;
            toScaleVec = Vector3.forward;
        }
        else if (CrossVec==Vector3.zero)
        {
           
            opposite = -1;
            toScaleVec = Vector3.back;
            //�޸�
        }
        else if (CrossVec == obj.up)
        {
            toScaleVec = Vector3.left;
            opposite = -1;
            //����� ���ʸ�
        }
        else if (CrossVec == -obj.up)
        {
            toScaleVec = Vector3.right;
            opposite = 1;
            //����� �����ʸ�
        }
        else if (CrossVec == -obj.right)
        {
            toScaleVec = Vector3.up;
            opposite = 1;
            //����� ����
        }
        else if (CrossVec == obj.right)
        {
            toScaleVec = Vector3.down;
            opposite = -1;
            //����� �Ʒ���
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
        for (int i = 0; i < manager.list.Count; i++)
        {

            if (manager.MouseWheelScroll > 0)
            {
                manager.list[i].transform.localScale += opposite * toScaleVec * multiplier;
                manager.list[i].transform.position += surface * (multiplier * 0.5f);
            }
            else if (manager.MouseWheelScroll < 0)
            {
                if (!(manager.list[i].transform.localScale.x <= 0.1f
                    || manager.list[i].transform.localScale.y <= 0.1f
                    || manager.list[i].transform.localScale.z <= 0.1f))
                {
                    manager.list[i].transform.localScale -= opposite * toScaleVec * multiplier;
                    manager.list[i].transform.position -= surface * (multiplier * 0.5f);
                }
                else
                { } 
                
            }
        }
        yield return null;    
    }
   
    
}
