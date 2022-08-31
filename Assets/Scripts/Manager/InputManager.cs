using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct BlockInfo
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}
public class InputManager : MonoBehaviour
{
    public const string MouseLeftClickName = "Fire1";
    public const string MouseRightClickName = "Fire2";
    public const string MouseWheelClickName = "Fire3";
    public const string MouseXoutName = "Mouse X";
    public const string MouseYoutName = "Mouse Y";
    public const string MouseScrollName = "Mouse ScrollWheel";

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
    /// Mouse Pointer�� ����Ű�� Object�� ������ ��ȯ 
    /// </summary>
    public BlockInfo PointBlockInformation { get; private set; }
    #endregion

    private void Update()
    {
        //if(ObjectHitPoint != Vector3.zero)
        //{
        //    Debug.Log($"ObjectHitPoint: {ObjectHitPoint}");
        //}
        //Debug.Log($"Position: {PointBlockInformation.position}\nRotation: {PointBlockInformation.rotation}\nScale: {PointBlockInformation.scale}");
        #region ���콺 ���� Input
        MouseLeftClick = Input.GetButton(MouseLeftClickName);
        MouseRightClick = Input.GetButton(MouseRightClickName);
        MouseWheelClick = Input.GetButton(MouseWheelClickName);
        MouseXOut = Input.GetAxis(MouseXoutName);
        MouseYOut = Input.GetAxis(MouseYoutName);
        MouseWheelScroll = Input.GetAxis(MouseScrollName);
        MousePosition = Input.mousePosition;
        #endregion

        #region ����Ű�� ��� ������Ʈ
        Vector3 mousepos = MousePosition;
        mousepos.z = mouseZMaxDistance;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector3 dir = worldPoint - screenPoint;
        Debug.DrawRay(screenPoint, dir.normalized * mouseZMaxDistance, Color.red);
        if (Physics.Raycast(screenPoint, dir.normalized * mouseZMaxDistance, out hit, mouseZMaxDistance))
        {
            //����Ű�� Object ���
            PointBlock = hit.collider.gameObject;

            //����ü�� ���� ���
            BlockInfo block;
            block.position = PointBlock.gameObject.transform.position;
            block.rotation = PointBlock.gameObject.transform.rotation.eulerAngles;
            block.scale = PointBlock.gameObject.transform.localScale;
            PointBlockInformation = block;
            
            //hitPoint ����
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
