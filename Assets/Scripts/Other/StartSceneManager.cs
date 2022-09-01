using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    float toLerp;
    [SerializeField]float h;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toLerp < 120)
        {
            toLerp = Mathf.Lerp(toLerp, h, 3* Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, toLerp);
            print(toLerp);
        }
        print(transform.rotation.eulerAngles);
        
    }
}
