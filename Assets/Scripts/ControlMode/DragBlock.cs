using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DragBlock : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private InputManager input;
    private bool isOnce = false;
    private GameObject selectBlock;
    private Vector3 newPos = Vector3.zero;
    private Vector3 hitNormal = Vector3.zero;
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
                hitNormal = input.ObjectHitNormal;
            }
            if (selectBlock)
            {
                newPos = new Vector3(Mathf.Clamp(selectBlock.transform.position.x - hitNormal.z * input.MouseXOut, -20, 20),
                     Mathf.Clamp(selectBlock.transform.position.y + input.MouseYOut, -20, 20),
                     Mathf.Clamp(selectBlock.transform.position.z + hitNormal.x * input.MouseXOut, -20, 20));

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
