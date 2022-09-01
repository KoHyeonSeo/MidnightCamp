using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LHE_SceneManagement : MonoBehaviour
{
    GameObject root;

    private void Start()
    {
        // 3D View���� ��ü ȸ�� �� �ٷ� 2D View�� �Ѿ�� ȸ���� ���·� ��鵵 ������ ���� �ذ�
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
