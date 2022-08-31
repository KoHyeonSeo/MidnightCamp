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
            // ���� ������Ʈ ���� 

            curTime += Time.deltaTime;
            if (curTime > 2)
            {
                //�� �������¿��� 2�� ������ �� �����ϸ�� �۵�

                //���⼭ ���콺Ŀ������ normal ���� ������ ���Ѵ�.
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
}
