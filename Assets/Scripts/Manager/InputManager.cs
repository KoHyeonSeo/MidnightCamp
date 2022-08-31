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

    [SerializeField] private float mouseZMaxDistance = 950f;
    private RaycastHit hit;

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

    /// <summary>
    /// Ctrl������, true�� ��ȯ (GetButtonDown)
    /// </summary>
    public bool CtrlKeyDown { get; private set; }
    #endregion

    #region ���� Input ���� ������Ƽ

    /// <summary>
    /// Left Shift �����鼭 ��Ŭ���� �ϸ� 1 ��ȯ
    /// </summary>
    public int SelectObject { get; private set; }
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
        SelectObject = Convert.ToInt32(Input.GetButton(ShiftName)) * Convert.ToInt32(Input.GetButtonDown(MouseLeftClickName));
        #endregion

        #region Ű���� �Է� ����
        CtrlKeyDown = Input.GetButtonDown(CtrlName);
        #endregion

        #region ����Ű�� ��� ������Ʈ
        Vector3 mousepos = MousePosition;
        mousepos.z = mouseZMaxDistance;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector3 dir = worldPoint - screenPoint;
        Debug.DrawRay(screenPoint, dir.normalized * mouseZMaxDistance, Color.red);
        LayerMask layer = 1 << LayerMask.NameToLayer("Grid");
        if (Physics.Raycast(screenPoint, dir.normalized * mouseZMaxDistance, out hit, mouseZMaxDistance, ~layer))
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
    }
}
