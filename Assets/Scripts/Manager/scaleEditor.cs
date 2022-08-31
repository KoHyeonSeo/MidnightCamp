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
        #region ���콺 Ŀ���� ������Ʈ�� ������ ��
        // ���콺 Ŭ���ϸ� ȭ����� ������Ʈ�� �����ϴ� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���� PointerBlock �� �����Ѵٸ� editor ��� ����
            if (manager.PointBlock != null)
            {
                // ���� ������Ʈ ���� 
                EditObject = manager.PointBlock;
                isClicked = true;
                print("111");
            }
            //���� �� ����� ������ ��� ������ ������ ������Ʈ���� �ٽ� �ʱ�ȭ �Ѵ�.
            else
            {
                EditObject = null;
                isClicked = false;
            }
        }
        #endregion
        #region ������Ʈ ��ũ�Ѱ� �����Ҷ� scale��  ����
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
            #region ������Ʈ ������ ����
            //���콺 Ŀ���� ������Ʈ�� ���� Ŭ������ �� �� ���� �������� ������ �� �ֵ��� �Ѵ�.

            #endregion


        }
        //������Ʈ�� ������ �����´�.
        if (manager.PointBlock)
        {
            Debug.Log($"Position: {manager.PointBlockInformation.position}\n" +
                $"Rotation: {manager.PointBlockInformation.rotation}\n" +
                $"Scale: {manager.PointBlockInformation.scale}");
        }
        oldScrollPoint = manager.MouseWheelScroll;
    }
}
