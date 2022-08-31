using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMode : MonoBehaviour
{

    private InputManager input;
    private bool deleteMode = false;
    private GameObject deleteObject;
    private void Start()
    {
        input = GetComponent<InputManager>();
    }
    private void Update()
    {

        #region 昏力 包访 角青
        if (input.MouseLeftClick && input.PointBlock)
        {
            deleteMode = true;
            deleteObject = input.PointBlock;
        }
        //Debug.Log(deleteMode);
        if (deleteMode)
        {
            if (input.DeleteKeyDown)
            {
                Debug.Log("昏力");
                Debug.Log(deleteObject);
                Destroy(deleteObject);
                deleteMode = false;
                deleteObject = null;
            }
            //else if (!input.DeleteKeyDown && Input.anyKeyDown)
            //{
            //    deleteMode = false;
            //    deleteObject = null;
            //}
        }
        if (input.CancelKeyDown)
        {
            deleteMode = false;
            deleteObject = null;
        }

        #endregion
    }
}
