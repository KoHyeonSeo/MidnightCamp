using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public const string MouseLeftClickName = "Fire1";
    public const string MouseRightClickName = "Fire2";
    public const string MouseXoutName = "Mouse X";
    public const string MouseYoutName = "Mouse Y";
    public const string MouseScrollName = "Mouse ScrollWheel";

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
    #endregion

    private void Update()
    {
        #region 마우스 관련 Input
        MouseLeftClick = Input.GetButton(MouseLeftClickName);
        MouseRightClick = Input.GetButton(MouseRightClickName);
        MouseXOut = Input.GetAxis(MouseXoutName);
        MouseYOut = Input.GetAxis(MouseYoutName);
        MouseWheelScroll = Input.GetAxis(MouseScrollName);
        MousePosition = Input.mousePosition;
        #endregion

        #region 가리키는 블록 업데이트
        Vector3 mousepos = MousePosition;
        mousepos.z = mouseZMaxDistance;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector3 dir = worldPoint - screenPoint;
        Debug.DrawRay(screenPoint, dir.normalized * mouseZMaxDistance, Color.red);
        if (Physics.Raycast(screenPoint, dir.normalized * mouseZMaxDistance, out hit, mouseZMaxDistance))
        {
            PointBlock = hit.collider.gameObject;
            ObjectHitPoint = hit.point;
        }
        else
        {
            PointBlock = null;
            ObjectHitPoint = Vector3.zero;
        }
        #endregion
    }
}
