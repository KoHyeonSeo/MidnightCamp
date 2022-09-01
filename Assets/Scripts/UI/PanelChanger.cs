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



public class PanelChanger : MonoBehaviour
{
    public Button Btn_Object;
    public Button Btn_Color;
    public Button Btn_Scale;

    public GameObject Panel_Menu;
    public GameObject Panel_Object;
    public GameObject Panel_Color;
    

    // Start is called before the first frame update
    void Start()
    {
        Panel_Menu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    public void Active_Object_Control_Panel()
    {
        // �ش� �г�,,�޴��г� Ȱ��ȭ ��Ű��, ������ �г��� Ȱ��ȭ ��Ű�� �ʴ´�.
        Panel_Menu.gameObject.SetActive(true);
        
        Panel_Object.gameObject.SetActive(true);        
        Panel_Color.gameObject.SetActive(false);

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

        GameManager.instance.curState = GameManager.Mode.ScaleEdit;
    }
}
