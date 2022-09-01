using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMode : MonoBehaviour
{
    private InputManager input;
    private bool isOnce = false;
    private GameObject selectObject;

    //Test��
    [SerializeField] private Material mat;
    
    //UI���Լ� ������ �����ͼ� ���õ� ������Ʈ�� ��Ƽ������ �ٲ��ָ� �ȴ�!

    private void Start()
    {
        input = GetComponent<InputManager>();
    }
    private void Update()
    {
        if (input.MouseLeftClick && input.PointBlock)
        {
            if (!isOnce)
            {
                isOnce = true;
                selectObject = input.PointBlock;
            }
            //UI���Լ� ��Ƽ���� ������ �޾Ƽ� ����
            //�� �ڵ�� Test��
            selectObject.GetComponent<MeshRenderer>().material = mat;
        }
        else
        {
            isOnce = false;
            selectObject = null;
        }

    }
}
