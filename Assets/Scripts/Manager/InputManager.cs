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

    #region 마우스 관련
    /// <summary>
    /// Mouse 왼쪽 버튼을 클릭하고 있을 시 true 반환 (GetButton)
    /// </summary>
    public bool MouseLeftClick { get; private set; }
    /// <summary>
    /// Mouse 오른쪽 버튼을 클릭하고 있을 시 true 반환 (GetButton)
    /// </summary>
    public bool MouseRightClick { get; private set; }
    /// <summary>
    /// 마우스 Wheel Click시 true 값 반환
    /// </summary>
    public bool MouseWheelClick { get; private set; }
    /// <summary>
    /// Mouse의 X좌표 움직임 값 반환
    /// </summary>
    public float MouseXOut { get; private set; }
    /// <summary>
    /// Mouse의 Y좌표 움직임 값 반환
    /// </summary>
    public float MouseYOut { get ; private set; }

    /// <summary>
    /// Mouse WheelScroll Value 값 반환
    /// </summary>
    public float MouseWheelScroll { get; private set; }

    /// <summary>
    /// Canvas 상에서 마우스 Position 값 반환
    /// </summary>
    public Vector3 MousePosition { get; private set; }

    /// <summary>
    /// Ctrl누르면, true를 반환 (GetButtonDown)
    /// </summary>
    public bool CtrlKeyDown { get; private set; }
    #endregion

    #region 조합 Input 관련 프로퍼티

    /// <summary>
    /// Left Shift 누르면서 좌클릭을 하면 1 반환
    /// </summary>
    public int SelectObject { get; private set; }
    #endregion

    #region 블록관련
    /// <summary>
    /// Mouse Pointer가 가리키는 블록의 GameObject를 반환
    /// </summary>
    public GameObject PointBlock { get; private set; }

    /// <summary>
    /// Mouse Pointer가 가리키는 블록의 hit Point를 반환 
    /// </summary>
    public Vector3 ObjectHitPoint { get; private set; }
    /// <summary>
    /// Mouse Pointer가 가리키는 블록의 hit Normal 반환 
    /// </summary>
    public Vector3 ObjectHitNormal { get; private set; }
    #endregion

    private void Update()
    {
        //ObjectHitPoint 간단 사용법
        //if(ObjectHitPoint != Vector3.zero)
        //{
        //    Debug.Log($"ObjectHitPoint: {ObjectHitPoint}");
        //}

        //PointBlockInformation 간단 사용법
        //if (PointBlock)
        //{
        //    Debug.Log($"Position: {PointBlockInformation.position}\n" +
        //        $"Rotation: {PointBlockInformation.rotation}\n" +
        //        $"Scale: {PointBlockInformation.scale}");
        //}

        //Debug.Log(SelectObject);

        #region 마우스 관련 Input
        MouseLeftClick = Input.GetButton(MouseLeftClickName);
        MouseRightClick = Input.GetButton(MouseRightClickName);
        MouseWheelClick = Input.GetButton(MouseWheelClickName);
        MouseXOut = Input.GetAxis(MouseXoutName);
        MouseYOut = Input.GetAxis(MouseYoutName);
        MouseWheelScroll = Input.GetAxis(MouseScrollName);
        MousePosition = Input.mousePosition;
        #endregion

        #region 조합 입력 관련
        SelectObject = Convert.ToInt32(Input.GetButton(ShiftName)) * Convert.ToInt32(Input.GetButtonDown(MouseLeftClickName));
        #endregion

        #region 키보드 입력 관련
        CtrlKeyDown = Input.GetButtonDown(CtrlName);
        #endregion

        #region 가리키는 블록 업데이트
        Vector3 mousepos = MousePosition;
        mousepos.z = mouseZMaxDistance;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector3 dir = worldPoint - screenPoint;
        Debug.DrawRay(screenPoint, dir.normalized * mouseZMaxDistance, Color.red);
        LayerMask layer = 1 << LayerMask.NameToLayer("Grid");
        if (Physics.Raycast(screenPoint, dir.normalized * mouseZMaxDistance, out hit, mouseZMaxDistance, ~layer))
        {
            //가리키는 Object 담기
            PointBlock = hit.collider.gameObject;

            //hitPoint 전달
            ObjectHitPoint = hit.point;

            //hitNormal 전달
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
