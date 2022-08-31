using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DragBlock : MonoBehaviour
{
    private InputManager input;
    private bool isOnce = false;
    private GameObject selectBlock;
    private void Start()
    {
        input = GetComponent<InputManager>();
    }
    private void Update()
    {
        if (input.MouseLeftClick)
        {
            if (!isOnce)
            {
                isOnce = true;
                selectBlock = input.PointBlock;
            }
            if (selectBlock)
            {
                Debug.Log(selectBlock);
                Vector3 newPos = new Vector3(selectBlock.transform.position.x + input.MouseXOut,
                    selectBlock.transform.position.y + input.MouseYOut,
                    selectBlock.transform.position.z);
                selectBlock.transform.position = newPos;
            }
        }
        else
        {
            isOnce = false;
            selectBlock = null;
        }
    }
}
