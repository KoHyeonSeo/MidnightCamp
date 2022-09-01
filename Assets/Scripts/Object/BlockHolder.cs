using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour
{
    Block block;

    MeshFilter meshFilter;
    Mesh mesh;
    
    MeshRenderer meshRenderer;
    Material material;

    void Awake()
    {
        block = new Block();
        
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshFilter == null || meshRenderer == null)
        {
            block.hasMesh = false;
        }
        else
        {
            block.hasMesh = true;
            mesh = meshFilter.mesh;
            material = meshRenderer.material;
        }

    }

    public int GetRootId()
    {
        return block.rootID;
    }
    
    public int GetID()
    {
        return block.ID;
    }

    public Texture2D GetTexture()
    {
        return material.GetTexture("_MainTex") as Texture2D;
    }
    
    public Texture2D GetNormal()
    {
        return material.GetTexture("_BumpMap") as Texture2D;
    }

    public void SetTexture(Texture2D texture)
    {
        material.SetTexture("_MainTex", texture);
    }

    public void SetNormal(Texture2D texture)
    {
        material.SetTexture("_BumpMap", texture);
    }
    public bool HasMesh()
    {
        return block.hasMesh;
    }

    public string ToJson()
    {
        BlockHolder Root = transform.parent.GetComponent<BlockHolder>();
        if (Root != null)
            block.rootID = Root.block.ID;
        block.position = transform.localPosition;
        block.rotation = transform.localRotation;
        block.scale = transform.localScale;

        block.m_name = transform.name;

        if (block.hasMesh)
        {
            block.vertices = mesh.vertices;
            block.triangles = mesh.triangles;
            block.uv = mesh.uv;
            block.uv2 = mesh.uv2;
            block.uv3 = mesh.uv3;
            block.uv4 = mesh.uv4;

            block.color = material.GetColor("_Color");
            block.metallic = material.GetFloat("_Metallic");
            block.smoothness = material.GetFloat("_Glossiness");

            block.texture = material.GetTexture("_MainTex") as Texture2D;
            block.normal = material.GetTexture("_BumpMap") as Texture2D;
        }
        return JsonUtility.ToJson(block);
    }

    public void FromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, block);

        transform.localPosition = block.position;
        transform.localRotation = block.rotation;
        transform.localScale = block.scale;

        if (block.hasMesh)
        {
            mesh = new Mesh();
            mesh.vertices = block.vertices;
            mesh.triangles = block.triangles;
            mesh.uv = block.uv;
            mesh.uv2 = block.uv2;
            mesh.uv3 = block.uv3;
            mesh.uv4 = block.uv4;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            meshFilter.mesh = mesh;

            material = new Material(Shader.Find("Standard"));
            material.SetColor("_Color", block.color);
            material.SetFloat("_Metallic", block.metallic);
            material.SetFloat("_Glossiness", block.smoothness);

            material.SetTexture("_MainTex", block.texture);
            material.SetTexture("_BumpMap", block.normal);

            meshRenderer.material = material;
        }
    }
}
