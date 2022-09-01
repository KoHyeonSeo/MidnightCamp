using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMode : MonoBehaviour
{
    private InputManager input;
    private bool isOnce = false;

    [SerializeField] private PanelChanger mat;
    
    //UI에게서 정보를 가져와서 선택된 오브젝트에 머티리얼을 바꿔주면 된다!

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
                    //UI에게서 머티리얼 정보를 받아서 적용
                    //이 코드는 Test용
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
