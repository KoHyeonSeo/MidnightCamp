using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHE_ObjectDontDestroy : MonoBehaviour
{
    public static LHE_ObjectDontDestroy Instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
