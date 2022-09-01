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
        
        #region ���콺 Ŀ���� ������Ʈ�� ������ ��
        // ���콺 Ŭ���ϸ� ȭ����� ������Ʈ�� �����ϴ� ����
        if (manager.MouseLeftClick)
        {
            // ���� PointerBlock �� �����Ѵٸ� editor ��� ����
           
            if (!isClicked)
            {
                EditObject = manager.PointBlock;
                area = manager.ObjectHitNormal;
                isClicked = true;
            }
            //���� ���� ���Ϳ� Ŭ���� ��ֺ����� �������� ���� ���ִٸ�

            curTime += Time.deltaTime;
            if (curTime > 1)
            {
                //�� �������¿��� 2�� ������ �� �����ϸ�� �۵�
                //���⼭ ���콺Ŀ������ normal ���� ������ ���Ѵ�.
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
        //���� �� ����� ������ ��� ������ ������ ������Ʈ���� �ٽ� �ʱ�ȭ �Ѵ�.
        else
        {
            EditObject = null;
            curTime = 0;
            isClicked = false;
        }
        #endregion
        #region ������Ʈ ��ũ�Ѱ� �����Ҷ� scale��  ����
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
            #region ������Ʈ ������ ����
            //���콺 Ŀ���� ������Ʈ�� ���� Ŭ������ �� �� ���� �������� ������ �� �ֵ��� �Ѵ�.

            #endregion


        //}
       
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
            multi = 1;
            toscaleVec = Vector3.forward;
        }
        else if (CrossVec==Vector3.zero)
        {
            print("��");
            multi = -1;
            toscaleVec = Vector3.back;
            //�޸�
        }
        else if (CrossVec == obj.up)
        {
            toscaleVec = Vector3.left;
            print("��");
            multi = -1;
            //����� ���ʸ�
        }
        else if (CrossVec == -obj.up)
        {
            toscaleVec = Vector3.right;
            multi = 1;
            print("��");
            //����� �����ʸ�
        }
        else if (CrossVec == -obj.right)
        {
            toscaleVec = Vector3.up;
            multi = 1;
            print("��");
            //����� ����
        }
        else if (CrossVec == obj.right)
        {
            toscaleVec = Vector3.down;
            multi = -1;
            print("�Ʒ�");
            //����� �Ʒ���
        }


    }
}
