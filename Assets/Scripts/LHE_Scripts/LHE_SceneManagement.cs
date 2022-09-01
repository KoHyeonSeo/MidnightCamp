using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LHE_SceneManagement : MonoBehaviour
{
    GameObject root;

    private void Start()
    {
        // 3D View에서 물체 회전 후 바로 2D View로 넘어가면 회전된 상태로 평면도 나오는 현상 해결
        root = GameObject.Find("Root");
        if (root)
        {
            root.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    private void Update()
    {

    }

    public void ObjectSceneLoad()
    {
        SceneManager.LoadScene("LHE_ObjectScene");
    }

    public void ThreeDimentionalViewLoad()
    {
        print("3D");
        SceneManager.LoadScene("LHE_3DScene");
    }

    public void TwoDimentionalViewLoad()
    {
        print("2D");
        SceneManager.LoadScene("LHE_2DScene");
    }
}
