using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    public const string MouseLeftClickName = "Fire1";
    public const string MouseRightClickName = "Fire2";
    public const string MouseWheelClickName = "Fire3";
    public const string MouseXoutName = "Mouse X";
    public const string MouseYoutName = "Mouse Y";
    public const string MouseScrollName = "Mouse ScrollWheel";
    public const string CtrlName = "Ctrl";
    public const string ShiftName = "Shift";
    public const string DeleteName = "Delete";
    public const string CancelName = "Cancel";
    public const string HorizontalName = "Horizontal";
    public const string VerticalName = "Vertical";

    [SerializeField] private float mouseZMaxDistance = 950f;
    public List<GameObject> list = new List<GameObject>();
    private RaycastHit hit;
    private bool isOnce = false;


    #region ���콺 ����
    /// <summary>
    /// Mouse ���� ��ư�� Ŭ���ϰ� ���� �� true ��ȯ (GetButton)
    /// </summary>
    public bool MouseLeftClick { get; private set; }
    /// <summary>
    /// Mouse ������ ��ư�� Ŭ���ϰ� ���� �� true ��ȯ (GetButton)
    /// </summary>
    public bool MouseRightClick { get; private set; }
    /// <summary>
    /// ���콺 Wheel Click�� true �� ��ȯ
    /// </summary>
    public bool MouseWheelClick { get; private set; }
    /// <summary>
    /// Mouse�� X��ǥ ������ �� ��ȯ
    /// </summary>
    public float MouseXOut { get; private set; }
    /// <summary>
    /// Mouse�� Y��ǥ ������ �� ��ȯ
    /// </summary>
    public float MouseYOut { get ; private set; }

    /// <summary>
    /// Mouse WheelScroll Value �� ��ȯ
    /// </summary>
    public float MouseWheelScroll { get; private set; }

    /// <summary>
    /// Canvas �󿡼� ���콺 Position �� ��ȯ
    /// </summary>
    public Vector3 MousePosition { get; private set; }
    #endregion

    #region Ű���� ���� ������Ƽ

    /// <summary>
    /// Ű���� ��: -1, ��: 1
    /// </summary>
    public float Horizontal { get; private set; }

    /// <summary>
    /// Ű���� ��: -1, ��: 1
    /// </summary>
    public float Vertical { get; private set; }

    /// <summary>
    /// Ctrl������, true�� ��ȯ (GetButtonDown)
    /// </summary>
    public bool CtrlKeyDown { get; private set; }
    /// <summary>
    /// Delete������, true�� ��ȯ (GetButtonDown)
    /// </summary>
    public bool DeleteKeyDown { get; private set; }
    /// <summary>
    /// Cancel������, true�� ��ȯ (GetButtonDown)
    /// </summary>
    public bool CancelKeyDown { get; private set; }
    #endregion

    #region ���� Input ���� ������Ƽ

    /// <summary>
    /// Left Shift ������ true ��ȯ (GetKeyDown)
    /// </summary>
    public bool SelectObject { get; private set; }
    #endregion

    #region ��ϰ���
    /// <summary>
    /// Mouse Pointer�� ����Ű�� ����� GameObject�� ��ȯ
    /// </summary>
    public GameObject PointBlock { get; private set; }

    /// <summary>
    /// Mouse Pointer�� ����Ű�� ����� hit Point�� ��ȯ 
    /// </summary>
    public Vector3 ObjectHitPoint { get; private set; }
    /// <summary>
    /// Mouse Pointer�� ����Ű�� ����� hit Normal ��ȯ 
    /// </summary>
    public Vector3 ObjectHitNormal { get; private set; }
    #endregion

    private void Update()
    {
        Debug.Log("1");
        //ObjectHitPoint ���� ����
        //if(ObjectHitPoint != Vector3.zero)
        //{
        //    Debug.Log($"ObjectHitPoint: {ObjectHitPoint}");
        //}

        //PointBlockInformation ���� ����
        //if (PointBlock)
        //{
        //    Debug.Log($"Position: {PointBlockInformation.position}\n" +
        //        $"Rotation: {PointBlockInformation.rotation}\n" +
        //        $"Scale: {PointBlockInformation.scale}");
        //}

        //Debug.Log(SelectObject);

        #region ���콺 ���� Input
        MouseLeftClick = Input.GetButton(MouseLeftClickName);
        MouseRightClick = Input.GetButton(MouseRightClickName);
        MouseWheelClick = Input.GetButton(MouseWheelClickName);
        MouseXOut = Input.GetAxis(MouseXoutName);
        MouseYOut = Input.GetAxis(MouseYoutName);
        MouseWheelScroll = Input.GetAxis(MouseScrollName);
        MousePosition = Input.mousePosition;
        #endregion

        #region ���� �Է� ����
        SelectObject = Input.GetButton("Shift");
        #endregion

        #region Ű���� �Է� ����
        CtrlKeyDown = Input.GetButtonDown(CtrlName);
        DeleteKeyDown = Input.GetButtonDown(DeleteName);
        CancelKeyDown = Input.GetButtonDown(CancelName);
        Horizontal = Input.GetAxis(HorizontalName);
        Vertical = Input.GetAxis(VerticalName);
        #endregion

        #region ����Ű�� ��� ������Ʈ
        Vector3 mousepos = MousePosition;
        mousepos.z = mouseZMaxDistance;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector3 dir = worldPoint - screenPoint;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(screenPoint, dir.normalized * mouseZMaxDistance, Color.red);
        LayerMask layer = 1 << LayerMask.NameToLayer("Grid");
        if (Physics.Raycast(screenPoint, dir.normalized * mouseZMaxDistance, out hit, mouseZMaxDistance, ~layer))
        //if(Physics.Raycast(ray, out hit, mouseZMaxDistance, ~layer))
        {
            //����Ű�� Object ���
            PointBlock = hit.collider.gameObject;

            //hitPoint ����
            ObjectHitPoint = hit.point;

            //hitNormal ����
            ObjectHitNormal = hit.normal;
        }
        else
        {
            PointBlock = null;
            ObjectHitPoint = Vector3.zero;
        }
        #endregion

        #region ���� ���� ��� ����
        //Shift ������ �� ������ Ŭ�� �� ����Ʈ�� ���
        //������ ����� �ٽ� ������ List���� Remove
        //Shift ������ ��� Ŭ���ϸ� ���
        if (SelectObject)
        {
            Debug.Log("3");
            if (MouseLeftClick && PointBlock)
            {
                if (!isOnce)
                {
                    isOnce = true;
                    if (!list.Contains(PointBlock))
                    {
                        PointBlock.GetComponent<Outline>().enabled = true;
                        list.Add(PointBlock);
                    }
                    else
                    {
                        PointBlock.GetComponent<Outline>().enabled = false;
                        list.Remove(PointBlock);
                    }
                }
            }
            else if (MouseLeftClick && !PointBlock)
            {
                for(int i = 0;i<list.Count; i++)
                {
                    list[i].GetComponent<Outline>().enabled = false;
                }
                list.Clear();
                isOnce = false;
            }
            else
                isOnce = false;
        }
        #endregion
    }
}