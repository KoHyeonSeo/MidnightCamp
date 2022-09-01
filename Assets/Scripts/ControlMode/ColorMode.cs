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
    
    //UI에게서 정보를 가져와서 선택된 오브젝트에 머티리얼을 바꿔주면 된다!

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
            //UI에게서 머티리얼 정보를 받아서 적용
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
