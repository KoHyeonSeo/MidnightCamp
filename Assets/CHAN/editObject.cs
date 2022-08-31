using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editObject : MonoBehaviour
{
    // 마우스로 오브젝트를 클릭하면 edit 모드로 전환하도록 만들것이다.
    // 오브젝트 하나만 클릭하면 하나만 설정되도록하고
    // 여러개 선택하면 여러게 edit 할 수 있도록 한다.
    
    // 오브젝트가 클릭되면 outline이 보이도록 한다. 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            //  수정하고자 하는 오브젝트를 가져온다.
            //  마우스 포인터의 위치 정보가  오브젝트 위치 정보와 같을 때

            // 그 오브젝트를 가져온다.

        }
    }
}
