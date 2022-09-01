using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBlock : MonoBehaviour
{
    [SerializeField] private float power = 4f;
    private InputManager input;
    private bool isOnce = false;
    
    private void Start()
    {
        input = GetComponent<InputManager>();
    }
    private void Update()
    {
        if (!input.SelectObject && input.MouseLeftClick)
        {
            if (!isOnce)
            {
                isOnce = true;
            }
            for (int i = 0; i < input.list.Count; i++)
            {
                if (input.list[i])
                {
                    Vector3 newRotation = input.list[i].transform.rotation.eulerAngles + new Vector3(input.MouseYOut, -input.MouseXOut, 0) * power;
                    input.list[i].transform.rotation = Quaternion.Euler(newRotation);
                }
            }
        }
        else
        {
            isOnce = false;
        }
    }
}
