using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Panel_Object_Controller : MonoBehaviour
{
    // 1. 버튼을 누르면 버튼에 해당하는 오브젝트를 생성한다.
    //    1) 각 버튼은 OnClickEvent로 오브젝트를 생성하는 함수를 호출한다.
    //    2) 각 버튼은 함수를 가진다.
    #region 추후신경
    // <<필요한 속성: 위치 ( position ) , ( rotation ), ( scale ) ==> 나중에 신경쓴다. 그냥 일단 만들고 본다.>>
    // 2. 해당 오브젝트는 위치, rotation, scale 속성을 가진다.
    //    1) 각 오브젝트의 속성을 불러오는 기능은 오브젝트를 생성하는 함수 안에 들어간다.
    //    2) 속성은 3가지이다.
    //    3) 속성의 값은 string 형태로 받아온다.
    // 3. 오브젝트의 속성에 대한 정보는 DB로 부터 받는다. => 해당사항 신경 X
    // 4. DB로 부터 네트워크를 통하여 받아온다. => DB와 연결하는 수신/발신에 해당하는 내용은 추후 진행한다.
    #endregion

    // 각 오브젝트 타입 별 버튼
    
    public Button Btn_Tetrahedron;
    public Button Btn_Hexahedron;
    public Button Btn_Sphere;
    public Button Btn_Capsule;
    public Button Btn_Cylinder;

    // 오브젝트 생성을 위한 변수
    public GameObject obj;

    // 

    // 루트 폴더의 위치정보를 담기 위한 변수
    public Transform root;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1. 해당하는 모양의 오브젝트를 생성한다.
    // 2. 생성하는데 필요한 오브젝트의 정보는 오브젝트들의 정보(Mesh)를 담는 변수에 들어가 있어야 한다.
    // 3. 변수에 들어가 있는 정보를 바탕으로 오브젝트를 실행하는 함수가 필요하다.
    // 4. 함수에 내부에서 포지션을 설정해 줄거야.

    public void Create_Tetrahedron()
    {
        GameObject gameObject = Instantiate(obj, transform.position, Quaternion.identity, root);
        // gameObject.GetComponent<BlockHolder>()
    }
    public void Create_Hexahedron()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }
    public void Create_Sphere()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }
    public void Create_Capsule()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }
    public void Create_Cylinder()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }



}
