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

        #region ���콺 Ŀ���� ������Ʈ�� ������ �� (���� ������Ʈ)
        // ���콺 Ŭ���ϸ� ȭ����� ������Ʈ�� �����ϴ� ����
        AddObject();
        if (manager.MouseLeftClick)
        {
            // ���� PointerBlock �� �����Ѵٸ� editor ��� ����


               
                
                isClicked = true;
            
            //���� ���� ���Ϳ� Ŭ���� ��ֺ����� �������� ���� ���ִٸ�

            curTime += Time.deltaTime;
            if (curTime > delayTime)
            {
                //�� �������¿��� 2�� ������ �� �����ϸ�� �۵�
                //���⼭ ���콺Ŀ������ normal ���� ������ ���Ѵ�.
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
        //���� ctrl Ű�� ������ �����̸� ����Ʈ�� ���������� ���ε� ���� 
        if (manager.MouseLeftClick&&!isClicked)
        {
            objectToScales.Add(manager.PointBlock);
            //���� �ߺ��������� ��� ����Ʈ�� ���� �ʴ´�.   
            surface = manager.ObjectHitNormal;
            isClicked = true;
        }
        if (manager.MouseLeftClick && manager.CtrlKeyDown)
        {
            //���� �ߺ��������� ��� ����Ʈ�� ���� �ʴ´�.
            objectToScales.Add(manager.PointBlock);
            //���� �ߺ��������� ��� ����Ʈ�� ���� �ʴ´�.   
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
                print("�ߺ�");
                //objectToScales.Remove(manager.PointBlock);
            }
            else
            {
               // objectToScales.Add(manager.PointBlock);
            }
        }


    }
}
