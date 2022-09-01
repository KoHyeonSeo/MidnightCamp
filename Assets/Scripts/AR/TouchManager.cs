using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchManager : MonoBehaviour
{
    private GameObject placeObject;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject block;

    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        placeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        placeObject.transform.localScale = Vector3.one * 0.05f;
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                //Instantiate(block, hits[0].pose.position, hits[0].pose.rotation);
                root.transform.position = hits[0].pose.position;
                root.transform.rotation = hits[0].pose.rotation;
            }
        }
    }
}
