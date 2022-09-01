using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHE_ObjectDontDestroy : MonoBehaviour
{
    public static LHE_ObjectDontDestroy Instance;

    private void Awake()
    {
        // 만약에 Instance가 null이라면
        if (Instance == null)
        {
            // Instance에 나를 넣겠다
            Instance = this;
            // Scene이 전환되어도 나를 파괴되지 않게 하겠다
            DontDestroyOnLoad(gameObject);
        }
        // 그렇지 않으면(이전에 만들어 놓은 애가 있다면)
        else
        {
            // 나를 파괴하겠다
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
