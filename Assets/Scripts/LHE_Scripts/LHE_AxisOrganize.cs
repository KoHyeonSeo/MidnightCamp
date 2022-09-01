using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHE_AxisOrganize : MonoBehaviour
{
    public GameObject axis;

    public void Organize()
    {
        GameObject root = GameObject.Find("Root");
        root.transform.rotation = Quaternion.Euler(Vector3.zero);

        axis.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
