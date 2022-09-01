using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMode : MonoBehaviour
{
    private InputManager input;
    private bool isOnce = false;
    private GameObject selectObject;
    private MeshRenderer meshRenderer;
    private Material material;
    
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
                meshRenderer = selectObject.GetComponent<MeshRenderer>();
                material = meshRenderer.material;
            }
            //UI���Լ� ��Ƽ���� ������ �޾Ƽ� ����
        }
        else
        {
            isOnce = false;
            selectObject = null;
            meshRenderer = null;
            material = null;
        }

    }
}
