using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Texture front;
    public Texture left;
    public Texture right;
    public Texture rear;
    public Texture up;

    string serverPath = "ftp://metaverse.ohgiraffers.com";

    public GameObject root;

    // trash
    public GameObject trash;

    public struct Thumbnail
    {
        public string url;
    }

    [System.Serializable]
    public struct BlockData
    {
        public int id;
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
        public string front;
        public string left;
        public string right;
        public string rear;
        public string up;
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
        projectName = "New Project";
        projectVersion = 1;
        projectDescription = "New Project Description";
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

    /*public void Post()
    {
        string uri = "http://test.co.kr/method";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.Method = "POST";
        request.ContentType = "application/json; utf-8";

        using (var streamWriter = new StreamWriter(request.GetRequestStream())) //전송
        {
            string json = "{\"type\":\"C\", \"title\": \"aa\", \"starttime\":\"" + pRdeDateInfo[0].StartDate.Replace("-", "")"}]}";
            streamWriter.Write(json);
        }

        var response = (HttpWebResponse)request.GetResponse(); //응답
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            var apiResult = streamReader.ReadToEnd();
            JObject jobj = JObject.Parse(apiResult);
            if (jobj["SCHEDULE"]["code"].ToString() == "00")
            {
                roomNumber = jobj["SCHEDULE"]["conferenceid"].ToString();
            }
        }
    }*/

    public async void SaveProject()
    {
        ProjectData projectData = new ProjectData();
        projectData.name = projectName;
        projectData.version = projectVersion;
        projectData.description = projectDescription;

        BlockHolder[] blockHolders = root.GetComponentsInChildren<BlockHolder>();
        projectData.blocks = new BlockData[blockHolders.Length];
        
        for (int i = 0; i < projectData.blocks.Length; i++)
        {
            projectData.blocks[i].id = blockHolders[i].GetID();
            
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
        Debug.LogAssertion(json);

        // post 추가
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
        string filePath = "texture/" + uniqueId.ToString() + ".json";
        await FTPManager.Instance.FtpUpload(filePath, texture.GetRawTextureData());
        return filePath;
    }

    async Task<string> UploadNormal(Texture2D texture)
    {
        Guid uniqueId = Guid.NewGuid();
        string filePath = "normal/" + uniqueId.ToString() + ".json";
        await FTPManager.Instance.FtpUpload(filePath, texture.GetRawTextureData());
        return filePath;
    }

    public async void OnClickUpload()
    {
        BlockHolder blockHolder = root.GetComponentInChildren<BlockHolder>();

        Texture2D texture = blockHolder.GetTexture();

        /*StartCoroutine(this.Upload(texture, (result) =>
        {
            Debug.Log("성공여부 : " + result);
        }));*/
        Guid uniqueId = Guid.NewGuid();
        await FTPManager.Instance.FtpUpload(uniqueId.ToString() + ".png", texture.GetRawTextureData());
        Texture2D texture2 = await FTPManager.Instance.FtpDownloadImage(uniqueId.ToString() + ".png");
        trash.GetComponent<MeshRenderer>().material.mainTexture = texture2;
    }

    // 추후 삭제
    void WriteJson(string filePath, string message)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);

        writer.WriteLine(message);
        writer.Close();
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
