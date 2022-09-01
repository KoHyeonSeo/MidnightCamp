using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LHE_2DViewMaximize : MonoBehaviour
{
    // 2D Camera
    [Header("Camera")]
    public Camera topCamera;
    public Camera frontCamera;
    public Camera leftCamera;
    public Camera blackCamera;

    // 마우스 관련
    float wheelValue = 0;
    // 스크롤 확대 배율
    public float zoomMultiplier = 1;


    [Header("All View Text")]
    public Text allViewTopText;
    public Text allViewFrontText;
    public Text allViewLeftText;

    [Header("Maximize View Text")]
    public Text maximizeViewFrontText;
    public Text maximizeViewLeftText;

    public void topViewMaximize()
    {
        topCamera.enabled = true;
        topCamera.rect = new Rect(0, 0, 1, 1);

        frontCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        frontCamera.enabled = false;
        leftCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
        leftCamera.enabled = false;
        blackCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        blackCamera.enabled = false;

        //text
        allViewTopText.enabled = true;
        allViewFrontText.enabled = false;
        allViewLeftText.enabled = false;
        maximizeViewFrontText.enabled = false;
        maximizeViewLeftText.enabled = false;
    }

    public void frontViewMaximize()
    {
        frontCamera.enabled = true;
        frontCamera.rect = new Rect(0, 0, 1, 1);

        topCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        topCamera.enabled = false;
        leftCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
        leftCamera.enabled = false;
        blackCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        blackCamera.enabled = false;

        //text
        allViewTopText.enabled = false;
        allViewFrontText.enabled = false;
        allViewLeftText.enabled = false;
        maximizeViewFrontText.enabled = true;
        maximizeViewLeftText.enabled = false;
    }

    public void leftViewMaximize()
    {
        leftCamera.enabled = true;
        leftCamera.rect = new Rect(0, 0, 1, 1);

        topCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        topCamera.enabled = false;
        frontCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        frontCamera.enabled = false;
        blackCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        blackCamera.enabled = false;

        //text
        allViewTopText.enabled = false;
        allViewFrontText.enabled = false;
        allViewLeftText.enabled = false;
        maximizeViewFrontText.enabled = false;
        maximizeViewLeftText.enabled = true;
    }

    // 4분할 화면 송출
    public void allViewEnable()
    {
        topCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        topCamera.enabled = true;
        frontCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        frontCamera.enabled = true;
        leftCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
        leftCamera.enabled = true;
        blackCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        blackCamera.enabled = true;

        //text
        allViewTopText.enabled = true;
        allViewFrontText.enabled = true;
        allViewLeftText.enabled = true;
        maximizeViewFrontText.enabled = false;
        maximizeViewLeftText.enabled = false;
    }

    private void Update()
    {
        wheelValue = Input.GetAxis("Mouse ScrollWheel");

        // 1. Top View Zoom In/Out
        if(topCamera.enabled == true && frontCamera.enabled == false && leftCamera.enabled == false && blackCamera.enabled == false)
        {
            topCamera.orthographicSize -= zoomMultiplier * wheelValue;
            if(topCamera.orthographicSize < 0.1f)
            {
                wheelValue = 0;
            }
        }

        // 2. Front View Zoom In/Out
        if (topCamera.enabled == false && frontCamera.enabled == true && leftCamera.enabled == false && blackCamera.enabled == false)
        {
            frontCamera.orthographicSize -= zoomMultiplier * wheelValue;
            if (frontCamera.orthographicSize < 0.1f)
            {
                wheelValue = 0;
            }
        }

        // 3. Left View Zoom In/Out
        if (topCamera.enabled == false && frontCamera.enabled == false && leftCamera.enabled == true && blackCamera.enabled == false)
        {
            leftCamera.orthographicSize -= zoomMultiplier * wheelValue;
            if (leftCamera.orthographicSize < 0.1f)
            {
                wheelValue = 0;
            }
        }
    }
}
