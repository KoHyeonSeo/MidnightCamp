using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Text;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using System.Net;

public class ProjectManager : MonoBehaviour
{
    public static ProjectManager instance;

    public string user;
    public string projectName;
    public int projectVersion;
    public string projectDescription;

    Texture front;
    Texture left;
    Texture right;
    Texture rear;
    Texture up;

    public string serverPath = "ftp://metaverse.ohgiraffers.com";

    public GameObject root;

    public struct Thumbnail
    {
        public string url;
    }

    [System.Serializable]
    public struct BlockData
    {
        public int rootID;
        public int ID;
        public string info_url;
        public string texture_url;
        public string normal_url;
    }

    [System.Serializable]
    public struct ProjectData
    {
        public string user;
        public string name;
        public int version;
        public string description;
        public string img_front_url;
        public string img_left_url;
        public string img_right_url;
        public string img_rear_url;
        public string img_up_url;
        public BlockData[] blocks;
    }

public string ProjectName
    {
        get { return projectName; }
        set { projectName = value; }
    }

    public int ProjectVersion
    {
        get { return projectVersion; }
        set { projectVersion = value; }
    }

    public string ProjectDescription
    {
        get { return projectDescription; }
        set { projectDescription = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }

    // 바이트 배열을 String으로 변환 
    private string ByteToString(byte[] strByte)
    {
        string str = Encoding.Default.GetString(strByte);
        return str;
    }
    
    // String을 바이트 배열로 변환 
    private byte[] StringToByte(string str)
    {
        byte[] StrByte = Encoding.UTF8.GetBytes(str);
        return StrByte;
    }

    public void OnClickSave()
    {
        SaveProject();
    }

    public async void SaveProject()
    {
        ProjectData projectData = new ProjectData();
        projectData.user = user;
        projectData.name = projectName;
        projectData.version = projectVersion;
        projectData.description = projectDescription;

        BlockHolder[] blockHolders = root.GetComponentsInChildren<BlockHolder>();
        projectData.blocks = new BlockData[blockHolders.Length];
        
        for (int i = 0; i < projectData.blocks.Length; i++)
        {
            projectData.blocks[i].rootID = blockHolders[i].GetRootId();
            projectData.blocks[i].ID = blockHolders[i].GetID();
            
            string filePath = await UploadJson(blockHolders[i].ToJson());
            projectData.blocks[i].info_url = filePath;

            if (blockHolders[i].HasMesh())
            {
                Texture2D texture = blockHolders[i].GetTexture();
                Texture2D normal = blockHolders[i].GetNormal();
                
                if (texture)
                {
                    filePath = await UploadTexture(blockHolders[i].GetTexture());
                    projectData.blocks[i].texture_url = filePath;
                }
                if (normal)
                {
                    filePath = await UploadNormal(blockHolders[i].GetNormal());
                    projectData.blocks[i].normal_url = filePath;
                }
            }
        }

        string json = JsonUtility.ToJson(projectData);
        //mDebug.LogAssertion(json);
        
        await HTTPManager.Instance.UploadProject(json);
    }

    // Upload Texture
    async Task<string> UploadJson(string json)
    {
        Guid uniqueId = Guid.NewGuid();
        string filePath = "info/" + uniqueId.ToString() + ".json";
        await FTPManager.Instance.FtpUpload(filePath, StringToByte(json));

        return filePath;
    }

    /*Task<string> DownloadJson(string filePath)
    {
        //FTPManager.Instance.FtpUpload(filePath, ByteToString(json));
    }*/

    async Task<string> UploadTexture(Texture2D texture)
    {
        Guid uniqueId = Guid.NewGuid();
        string filePath = "texture/" + uniqueId.ToString() + ".png";
        await FTPManager.Instance.FtpUpload(filePath, texture.GetRawTextureData());
        return filePath;
    }

    async Task<string> UploadNormal(Texture2D texture)
    {
        Guid uniqueId = Guid.NewGuid();
        string filePath = "normal/" + uniqueId.ToString() + ".png";
        await FTPManager.Instance.FtpUpload(filePath, texture.GetRawTextureData());
        return filePath;
    }

    /*private IEnumerator Upload(Texture2D texture, System.Action<string> OnCompleteUpload)
    {
        //이미지 sprite -> texture2d로 변환후 png로 변환
        *//*var img = this.sampleImage;
        var newTex = new Texture2D((int)img.rect.width, (int)img.rect.height);
        var newColors = img.texture.GetPixels((int)img.textureRect.x, (int)img.textureRect.y, (int)img.textureRect.width, (int)img.textureRect.height);
        newTex.SetPixels(newColors);
        newTex.Apply();
        var tex = ImageConversion.EncodeToPNG(newTex);*//*

        //var byteArr = Encoding.UTF8.GetBytes(data);
        byte[] byteArr = texture.GetRawTextureData();
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormFileSection("imgfile", byteArr, "sampleimage.png", "image/png"));

        var path = string.Format("{0}/{1}", this.serverPath, "api/uploadimage");
        UnityWebRequest webRequest = UnityWebRequest.Post(path, formData);
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        print(path);
        print(formData);

        yield return webRequest.SendWebRequest();

        var result = webRequest.downloadHandler.text;
        OnCompleteUpload(webRequest.responseCode.ToString());
    }*/
}
