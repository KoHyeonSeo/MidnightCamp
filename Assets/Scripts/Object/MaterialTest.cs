using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        material = meshRenderer.material;
        /*material.shader.GetPropertyCount();
        for (int i = 0; i < material.shader.GetPropertyCount(); i++)
        {
            Debug.Log(material.shader.GetPropertyName(i));
        }*/

        Color color = material.GetColor("_Color");
        float metallic = material.GetFloat("_Metallic");
        float smoothness = material.GetFloat("_Glossiness");
        
        Texture2D texture = material.GetTexture("_MainTex") as Texture2D;
        if (texture != null)
        {
            byte[] bytes = texture.GetRawTextureData();
            print(bytes.Length);
            print(JsonUtility.ToJson(bytes));
            //print(JsonUtility.ToJson(texture));
            
            /*Texture2DData texture2DData = new Texture2DData(texture);
            print(JsonUtility.ToJson(texture2DData));*/
        }
        //Texture2D normal = material.GetTexture("_BumpMap") as Texture2D;

        //color = new Color(1f, 1f, 1f, 1.0f);
        //material.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
