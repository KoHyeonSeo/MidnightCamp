using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditCameraMove : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed = 5f;

    //private void Start()
    //{
    //    inputManager = GetComponent<InputManager>();
    //}

    private void Update()
    {
        if (inputManager.MouseRightClick)
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.x -= inputManager.MouseYOut * 2;
            euler.y += inputManager.MouseXOut * 2; 
            transform.rotation = Quaternion.Euler(euler);
            Vector3 dir = inputManager.Horizontal * Vector3.right + inputManager.Vertical * Vector3.forward;
            // -> 내가 바라보는 방향을 기준으로 가고 싶다.
            dir = Camera.main.transform.TransformDirection(dir);
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
