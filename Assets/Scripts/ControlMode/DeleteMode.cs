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

        #region 삭제 관련 실행
        //Debug.Log(deleteMode);

        if (input.DeleteKeyDown)
        {
            for (int i = 0; i < input.list.Count; i++)
            {
                if (input.list[i])
                {
                    Debug.Log("삭제");
                    Debug.Log(input.list[i]);
                    Destroy(input.list[i]);
                }
            }
        }
        #endregion
    }
}
