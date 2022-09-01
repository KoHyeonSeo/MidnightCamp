using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DragBlock : MonoBehaviour
{
    private InputManager input;
    private bool isOnce = false;
    private Vector3 hitNormal = Vector3.zero;
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
                hitNormal = input.ObjectHitNormal;
            }
            for (int i = 0; i < input.list.Count; i++)
            {
                if (input.list[i])
                {
                    Vector3 newPos = new Vector3(Mathf.Clamp(input.list[i].transform.position.x - hitNormal.z * input.MouseXOut * 0.5f, -20, 20),
                         Mathf.Clamp(input.list[i].transform.position.y + input.MouseYOut * 0.5f, -20, 20),
                         Mathf.Clamp(input.list[i].transform.position.z + hitNormal.x * input.MouseXOut * 0.5f, -20, 20));

                    input.list[i].transform.position = newPos;
                }
            }
        }
        else
        {
            isOnce = false;
        }
    }
}
