using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class DeleteMode : MonoBehaviour
{

    private InputManager input;
    private void Start()
    {
        input = GetComponent<InputManager>();
    }
    private void Update()
    {

        #region ���� ���� ����
        //Debug.Log(deleteMode);

        if (input.DeleteKeyDown)
        {
            for (int i = 0; i < input.list.Count; i++)
            {
                if (input.list[i])
                {
                    Debug.Log("����");
                    Debug.Log(input.list[i]);
                    Destroy(input.list[i]);
                }
            }
        }
        #endregion
    }
}
