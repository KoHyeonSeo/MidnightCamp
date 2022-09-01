using System.Collections;
using System.Collections.Generic;
using System.Linq; // �߰�
using UnityEngine;

// 1. "Root"(Ȥ�� "Object")�κ��� ��� �ڽı����� ���͸� ���Ѵ�
// 2. ���� ���͸� �����Ͽ� �ִ�/�ּ� X, Y, Z���� ���Ѵ�(�� ��Ȯ�Ϸ��� �׵��� scale������ ���ؾ������� �ϴ��� pivot�� �������� ..^^)
// 3. X, Y�� ���ؼ��� �ִ�&�ּ��� ��հ��� ��ġ�ϵ���, Z�� ���ؼ��� �ִ밪���� ���� �Ÿ���ŭ ������ ���� ��ġ�ϵ��� ī�޶� ��ġ(�̰��� 3D & 2D������)

public class LHE_CalculateMaxDistance : MonoBehaviour
{
    // �θ������Ʈ�� Root ã��
    GameObject root;

    // List ����
    List<Vector3> toChildVector = new List<Vector3>();
    List<float> toChildX = new List<float>();
    List<float> toChildY = new List<float>();
    List<float> toChildZ = new List<float>();

    // X, Y�� Max<->Min ��հ�
    public float averageX;
    public float averageY;
    public float averageZ;
    // Z�� Max��
    public float maxZ;
    public float maxY;
    public float minX;


    public static LHE_CalculateMaxDistance Instance;
    private void Awake()
    {
        // ���࿡ Instance�� null�̶��
        if (Instance == null)
        {
            // Instance�� ���� �ְڴ�
            Instance = this;
            // Scene�� ��ȯ�Ǿ ���� �ı����� �ʰ� �ϰڴ�
            DontDestroyOnLoad(gameObject);
        }
        // �׷��� ������(������ ����� ���� �ְ� �ִٸ�)
        else
        {
            // ���� �ı��ϰڴ�
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("Root");
        //print("childcount " + root.transform.childCount); // 6 ���� ��ȯ

        //for(int i = 0; i < root.transform.childCount; i++)
        //{
        //    toChildVector.Add(root.transform.GetChild(i).gameObject.transform.position - root.transform.position);
        //    print(toChildVector[i]); // 6�� ���� ���� ��ȯ

        //}

        for (int i = 0; i < root.transform.childCount; i++)
        {
            toChildX.Add((root.transform.GetChild(i).gameObject.transform.position - root.transform.position).x);
            toChildY.Add((root.transform.GetChild(i).gameObject.transform.position - root.transform.position).y);
            toChildZ.Add((root.transform.GetChild(i).gameObject.transform.position - root.transform.position).z);

            //print(toChildX[i]); // �������
            //print(toChildY[i]); // �������
            //print(toChildZ[i]); // �������
        }

        //print(toChildX.Max()); // �������
        //print(toChildX.Min()); // �������

        // X, Y�� Max<->Min ��հ�
        averageX = (toChildX.Max() + toChildX.Min()) / 2;
        averageY = (toChildY.Max() + toChildY.Min()) / 2;
        averageZ = (toChildZ.Max() + toChildZ.Min()) / 2;
        //print("averageX " + averageX); // �������
        //print("averageY " + averageY); // �������

        // Z�� Max��
        maxZ = toChildZ.Max();
        maxY = toChildY.Max();
        minX = toChildX.Min();
        //print("maxZ " + maxZ); // �������
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
