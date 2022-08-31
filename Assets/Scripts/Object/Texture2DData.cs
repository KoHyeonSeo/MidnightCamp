using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Texture2DData
{
    public Color32Data[] Color32Datas;
    public int width, height;
    public Texture2DData(Texture2D source)
    {
        Color32[] colors = source.GetPixels32();
        this.width = source.width;
        this.height = source.height;
        this.Color32Datas = new Color32Data[colors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            this.Color32Datas[i] = new Color32Data(colors[i]);
        }
    }

    public Texture2D Recreate()
    {
        Texture2D tex = new Texture2D(this.width, this.height);
        Color32[] pixels = new Color32[this.Color32Datas.Length];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = new Color32(this.Color32Datas[i].r
                                      , this.Color32Datas[i].g
                                      , this.Color32Datas[i].b
                                      , this.Color32Datas[i].a);
        }
        tex.SetPixels32(pixels);
        tex.Apply();
        return tex;
    }

    [System.Serializable]
    public class Color32Data
    {
        public byte a, r, g, b;
        public Color32Data(Color32 source)
        {
            this.a = source.a;
            this.r = source.r;
            this.g = source.g;
            this.b = source.b;
        }
    }

}
