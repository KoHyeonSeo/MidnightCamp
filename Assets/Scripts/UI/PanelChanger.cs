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
using Color = UnityEngine.Color;

public class PanelChanger : MonoBehaviour
{
    public Button Btn_Object;
    public Button Btn_Color;
    public Button Btn_Scale;

    public GameObject Panel_Menu;
    public GameObject Panel_Object;
    public GameObject Panel_Color;

    SpriteRenderer sr;
    public GameObject Color_Info;
    // 색상값 입력 부
    public GameObject Input_Red_Value;
    public GameObject Input_Green_Value;
    public GameObject Input_Blue_Value;
    public GameObject Input_A_transParant_Value;
    
    // 입력된 색상값을 받을 변수
    float Red;
    float Green;
    float Blue;
    float A_Transparant;
    public Color color_info;

    // Start is called before the first frame update
    void Start()
    {
        Panel_Menu.gameObject.SetActive(true);        
    }

    // Update is called once per frame
    void Update()
    {
        // 패널에 해당하는 상태로 전환한다.
        if (GameManager.instance.curState == GameManager.Mode.ColorChange)   // 해당하는 패널위에 정보창을 띄울 것입니다.
        {
            // 1. 정보창은 오브젝트를 클릭하는 경우, 오브젝트가 가지고 있는 정보를 가져와서 정보창에 띄웁니다. (동작에 대하여... 최종적으로...)

            // ==> MeshRender에 보낼 정보는 R값, G값, B값, A값, Hexademical 입니다.
            // ==> 정보를 직접 입력할 수 있는 창 5개(text)
            // ==> 정보를 마우스커서로 드래그 할 수 있는 창 5개 필요함.
            // ==> text -> 드래그 창, 드래그 창 -> text 모두 가능해야 합니다. => 입력이 완료되는 경우, 반대쪽 창을 변경 할 수 있어야 합니다.

            // 0. 입력된 RGVA값을 받아와서 해당 변수에 저장한다.
            if (Input_Red_Value.GetComponent<InputField>().text != null)
            {
                Red = float.Parse(Input_Red_Value.GetComponent<InputField>().text);
            }
            if (Input_Green_Value.GetComponent<InputField>().text != null)
            {
                Red = float.Parse(Input_Green_Value.GetComponent<InputField>().text);
            }
            if (Input_Blue_Value.GetComponent<InputField>().text != null)
            {
                Red = float.Parse(Input_Blue_Value.GetComponent<InputField>().text);
            }
            if (Input_A_transParant_Value.GetComponent<InputField>().text != null)
            {
                Red = float.Parse(Input_A_transParant_Value.GetComponent<InputField>().text);
            }

            // 1. RGVA값을 저장 할 SpriteRenderer의 sr 변수
            color_info = new Color(Red / 255f, Green / 255f, Blue / 255f, A_Transparant / 255f);
        }
        
    }

    public void Active_Object_Control_Panel()
    {
        // 해당 패널,,메뉴패널 활성화 시키고, 나머지 패널은 활성화 시키지 않는다.
        Panel_Menu.gameObject.SetActive(true);
        
        Panel_Object.gameObject.SetActive(true);        
        Panel_Color.gameObject.SetActive(false);

        // 패널에 해당하는 상태로 전환한다.
        if (Panel_Object.activeSelf == true)
        {
            GameManager.instance.curState = GameManager.Mode.Move;
        }
    }
    public void Active_Color_Info_Panel()
    {
        // 해당 패널,,메뉴패널 활성화 시키고, 나머지 패널은 활성화 시키지 않는다.
        Panel_Menu.gameObject.SetActive(true);
        
        Panel_Object.gameObject.SetActive(false);        
        Panel_Color.gameObject.SetActive(true);

        // 패널에 해당하는 상태로 전환한다.
        if (Panel_Color.activeSelf == true)
        {
            GameManager.instance.curState = GameManager.Mode.ColorChange;
        }    
    }
    public void Active_Scale_Mode()
    {
        // 메뉴패널 활성화 시키고, Active_Scale_Mode() 가 발동되는 경우, ScaleEditMode로 변경한다.
        Panel_Menu.gameObject.SetActive(true);

        Panel_Object.gameObject.SetActive(false);
        Panel_Color.gameObject.SetActive(false);

        // 패널에 해당하는 상태로 전환한다.
        GameManager.instance.curState = GameManager.Mode.ScaleEdit;
    }
}
