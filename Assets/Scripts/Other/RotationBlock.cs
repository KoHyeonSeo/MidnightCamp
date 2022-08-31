using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBlock : MonoBehaviour
{
    [SerializeField] private float power = 4f;
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
                Vector3 newRotation = selectBlock.transform.rotation.eulerAngles + new Vector3(input.MouseYOut, -input.MouseXOut, 0) * power;
                selectBlock.transform.rotation = Quaternion.Euler(newRotation);
            }
        }
        else
        {
            isOnce = false;
            selectBlock = null;
        }
    }
}
