using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMode : MonoBehaviour
{
    private InputManager input;
    private bool isOnce = false;

    [SerializeField] private PanelChanger mat;
    
    //UI���Լ� ������ �����ͼ� ���õ� ������Ʈ�� ��Ƽ������ �ٲ��ָ� �ȴ�!

    private void Start()
    {
        input = GetComponent<InputManager>();
    }
    private void Update()
    {
        if (!input.SelectObject && input.MouseLeftClick && input.PointBlock)
        {
            if (!isOnce)
            {
                isOnce = true;
            }
            for (int i = 0; i < input.list.Count; i++)
            {
                if (input.list[i])
                {
                    //UI���Լ� ��Ƽ���� ������ �޾Ƽ� ����
                    //�� �ڵ�� Test��
                    input.list[i].GetComponent<MeshRenderer>().material.color = mat.color_info;
                }
            }
        }
        else
        {
            isOnce = false;
        }

    }
}
