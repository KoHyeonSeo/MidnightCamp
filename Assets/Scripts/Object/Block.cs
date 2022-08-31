using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block
{
    public int rootID = 0;
    public int ID;
    
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    
    public string m_name;

    public bool hasMesh;
    
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uv;
    public Vector2[] uv2;
    public Vector2[] uv3;
    public Vector2[] uv4;

    public Block()
    {
        ID = GetHashCode();
    }
}
