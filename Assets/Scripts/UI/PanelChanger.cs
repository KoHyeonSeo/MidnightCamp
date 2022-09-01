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
using TMPro;

public class PanelChanger : MonoBehaviour
{
    public Button Btn_Object;
    public Button Btn_Color;
    public Button Btn_Scale;
    public Button Btn_Rotate;
    public Button Btn_Delete;
    public Button Btn_Move;

    public GameObject Panel_Menu;
    public GameObject Panel_Object;
    public GameObject Panel_Color;
    
    // ���� �Է��ʵ�
    public GameObject Input_Red_Value;
    public GameObject Input_Green_Value;
    public GameObject Input_Blue_Value;
    public GameObject Input_A_transParant_Value;
    
    // �Էµ� ������ ���� ����
    float Red;
    float Green;
    float Blue;
    float A_Transparant;
    
    // ������ ������ ���󺯼�
    public Color color_info;

    // Start is called before the first frame update
    void Start()
    {
        Panel_Menu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // �гο� �ش��ϴ� ���·� ��ȯ�Ѵ�.
        if (GameManager.instance.curState == GameManager.Mode.ColorChange)   // �ش��ϴ� �г����� ����â�� ��� ���Դϴ�. (��)
        {
            // 1. ����â�� ������Ʈ�� Ŭ���ϴ� ���, ������Ʈ�� ������ �ִ� ������ �����ͼ� ����â�� ���ϴ�. (���ۿ� ���Ͽ�... ����������...) (��)

            // ==> MeshRender�� ���� ������ R��, G��, B��, A�� �Դϴ�. (��)
            // ==> ������ ���� �Է��� �� �ִ� â 5��(text) (��)
            // ==> ������ ���콺Ŀ���� �巡�� �� �� �ִ� â 5�� �ʿ���.
            // ==> text -> �巡�� â, �巡�� â -> text ��� �����ؾ� �մϴ�. => �Է��� �Ϸ�Ǵ� ���, �ݴ��� â�� ���� �� �� �־�� �մϴ�.

            // 0. �Էµ� RGVA���� �޾ƿͼ� �ش� ������ �����Ѵ�.

            TMP_InputField tmpInputField_R = Input_Red_Value.GetComponent<TMP_InputField>();
            TMP_InputField tmpInputField_G = Input_Green_Value.GetComponent<TMP_InputField>();
            TMP_InputField tmpInputField_V = Input_Blue_Value.GetComponent<TMP_InputField>();
            TMP_InputField tmpInputField_A = Input_A_transParant_Value.GetComponent<TMP_InputField>();

            if (tmpInputField_R.text.Length > 0)
            {
                Red = float.Parse(Input_Red_Value.GetComponent<TMP_InputField>().text);
            }
            if (tmpInputField_G.text.Length > 0)
            {
                Red = float.Parse(Input_Green_Value.GetComponent<TMP_InputField>().text);
            }
            if (tmpInputField_V.text.Length > 0)
            {
                Red = float.Parse(Input_Blue_Value.GetComponent<TMP_InputField>().text);
            }
            if (tmpInputField_A.text.Length > 0)
            {
                Red = float.Parse(Input_A_transParant_Value.GetComponent<TMP_InputField>().text);
            }            

            // 1. RGVA���� ������.
            color_info = new Color(Red / 255f, Green / 255f, Blue / 255f, A_Transparant / 255f);
        }
        
    }

    public void Active_Object_Control_Panel()
    {
        // �ش� �г�,,�޴��г� Ȱ��ȭ ��Ű��, ������ �г��� Ȱ��ȭ ��Ű�� �ʴ´�.
        Panel_Menu.gameObject.SetActive(true);
        
        Panel_Object.gameObject.SetActive(true);        
        Panel_Color.gameObject.SetActive(false);

        // �гο� �ش��ϴ� ���·� ��ȯ�Ѵ�.
        if (Panel_Object.activeSelf == true)
        {
            GameManager.instance.curState = GameManager.Mode.Move;
        }
    }
    public void Active_Color_Info_Panel()
    {
        // �ش� �г�,,�޴��г� Ȱ��ȭ ��Ű��, ������ �г��� Ȱ��ȭ ��Ű�� �ʴ´�.
        Panel_Menu.gameObject.SetActive(true);
        
        Panel_Object.gameObject.SetActive(false);        
        Panel_Color.gameObject.SetActive(true);

        // �гο� �ش��ϴ� ���·� ��ȯ�Ѵ�.
        if (Panel_Color.activeSelf == true)
        {
            GameManager.instance.curState = GameManager.Mode.ColorChange;
        }    
    }
    public void Active_Scale_Mode()
    {
        // �޴��г� Ȱ��ȭ ��Ű��, Active_Scale_Mode() �� �ߵ��Ǵ� ���, ScaleEditMode�� �����Ѵ�.
        Panel_Menu.gameObject.SetActive(true);

        Panel_Object.gameObject.SetActive(false);
        Panel_Color.gameObject.SetActive(false);

        // �гο� �ش��ϴ� ���·� ��ȯ�Ѵ�.
        GameManager.instance.curState = GameManager.Mode.ScaleEdit;
    }
    public void Active_Rotate_Mode()
    {
        GameManager.instance.curState = GameManager.Mode.Rotate;
    }
    public void Active_Delete_Mode()
    {
        GameManager.instance.curState = GameManager.Mode.Delete;
    }
    public void Active_Move_Mode()
    {
        GameManager.instance.curState = GameManager.Mode.Move;
    }
}
