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
        if (manager.MouseLeftClick)
        {
            // ���� PointerBlock �� �����Ѵٸ� editor ��� ����
           
            if (!isClicked)
            {
                objectToScale = manager.PointBlock;
                surface = manager.ObjectHitNormal;
                isClicked = true;
            }
            //���� ���� ���Ϳ� Ŭ���� ��ֺ����� �������� ���� ���ִٸ�

            curTime += Time.deltaTime;
            if (curTime > delayTime)
            {
                //�� �������¿��� 2�� ������ �� �����ϸ�� �۵�
                //���⼭ ���콺Ŀ������ normal ���� ������ ���Ѵ�.
                FindDir(objectToScale.transform, surface);
                ScaleObj();
            }
        } 
        else
        {
            objectToScale = null;
            curTime = 0;
            isClicked = false;
        }
        #endregion
        #region ���� ������Ʈ�� ������ ��
        if (manager.SelectObject)
        {
                objectToScales.Add(manager.PointBlock);
                
        }
        curTime += Time.deltaTime;
        if (curTime > delayTime)
        {
            FindDir(objectToScales[0].transform, surface);
            StartCoroutine(ScaleObjs());
        }
        else
        {
            objectToScale = null;
            curTime = 0;
            isClicked = false;
        }
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
            print("��");
            opposite = -1;
            toScaleVec = Vector3.back;
            //�޸�
        }
        else if (CrossVec == obj.up)
        {
            toScaleVec = Vector3.left;
            print("��");
            opposite = -1;
            //����� ���ʸ�
        }
        else if (CrossVec == -obj.up)
        {
            toScaleVec = Vector3.right;
            opposite = 1;
            print("��");
            //����� �����ʸ�
        }
        else if (CrossVec == -obj.right)
        {
            toScaleVec = Vector3.up;
            opposite = 1;
            print("��");
            //����� ����
        }
        else if (CrossVec == obj.right)
        {
            toScaleVec = Vector3.down;
            opposite = -1;
            print("�Ʒ�");
            //����� �Ʒ���
        }
    }
    void ScaleObj()
    {
        if (manager.MouseWheelScroll > 0)
        {
            objectToScale.transform.localScale += opposite * toScaleVec * multiplier;
            objectToScale.transform.position += surface * (multiplier * 0.5f);
        }
        else if (manager.MouseWheelScroll < 0)
        {
            if (!(objectToScale.transform.localScale.x <= 0.1f
                || objectToScale.transform.localScale.y <= 0.1f
                || objectToScale.transform.localScale.z <= 0.1f))
            {
                objectToScale.transform.localScale -= opposite * toScaleVec * multiplier;
                objectToScale.transform.position -= surface * (multiplier * 0.5f);
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
                if (!(objectToScale.transform.localScale.x <= 0.1f
                    || objectToScale.transform.localScale.y <= 0.1f
                    || objectToScale.transform.localScale.z <= 0.1f))
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
}
