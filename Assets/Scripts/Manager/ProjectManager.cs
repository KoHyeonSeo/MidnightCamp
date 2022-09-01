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
using System.Numerics;

public class ProjectManager : MonoBehaviour
{
    public static ProjectManager instance;

    public string user;
    public string projectName;
    public int projectVersion;
    public string projectDescription;

    // 블럭 관련
    public GameObject cube;
    //public GameObject ;

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
    private void DeleteChild(GameObject parent)
    {
        for(int i= 0; i < parent.transform.childCount; i++)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
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
        //LoadProject();
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
    public void OnClickLoad()
    {
        LoadProject();
    }
    public void OnClickSave()
    {
        SaveProject();
    }
    private List<List<int>> nodes = new List<List<int>>();
    private void GraphNodes(ProjectData data)
    {
        for(int i = 0; i< data.blocks.Length; i++)
        {
            nodes.Add(new List<int>());
            for (int j = 0; j < data.blocks.Length; j++)
            {
                nodes[i].Add(-1);
            }
        }
        //자신의 자식이 누가 있는지 판단. 기본적으로 -1(root)이 들어있음
        for(int i = 0; i < data.blocks.Length; i++)
        {
            for(int j = 0; j < data.blocks.Length; j++)
            {
                if (i == j)
                    continue;
                if (data.blocks[i].ID == data.blocks[j].rootID)
                    nodes[i].Add(j);
            }
        }
    }
    public async void LoadProject()
    {
        string filePath = "info/f3962c8c-1579-4fbb-a73b-bacf22152fe5.json";
        //string test = await DownloadJson(filePath);
        string test = "{\r\n  \"user\": \"pkch0102\",\r\n  \"name\": \"New Project\",\r\n  \"version\": 1,\r\n  \"description\": \"New Project Description\",\r\n  \"img_front_url\": \"\",\r\n  \"img_left_url\": \"\",\r\n  \"img_right_url\": \"\",\r\n  \"img_rear_url\": \"\",\r\n  \"img_up_url\": \"\",\r\n  \"blocks\": [\r\n    {\r\n      \"rootID\": 0,\r\n      \"ID\": 1265542050,\r\n      \"info_url\": \"info/4a811a76-f7b7-4431-b363-c2ada2df11b0.json\",\r\n      \"texture_url\": \"\",\r\n      \"normal_url\": \"\"\r\n    },\r\n    {\r\n      \"rootID\": 1265542050,\r\n      \"ID\": -1297469844,\r\n      \"info_url\": \"info/caa5c34e-94e1-4407-9e8e-67250a933a16.json\",\r\n      \"texture_url\": \"\",\r\n      \"normal_url\": \"\"\r\n    },\r\n    {\r\n      \"rootID\": 0,\r\n      \"ID\": -179460082,\r\n      \"info_url\": \"info/c5a43baa-4026-4fa1-9c83-9d86382774fe.json\",\r\n      \"texture_url\": \"\",\r\n      \"normal_url\": \"\"\r\n    },\r\n    {\r\n      \"rootID\": -179460082,\r\n      \"ID\": 651596410,\r\n      \"info_url\": \"info/c7b536b4-a1b7-4bd4-b659-1b326cde55b8.json\",\r\n      \"texture_url\": \"\",\r\n      \"normal_url\": \"\"\r\n    },\r\n    {\r\n      \"rootID\": 651596410,\r\n      \"ID\": -1911415484,\r\n      \"info_url\": \"info/034a4219-4809-4d29-896e-05490da298c3.json\",\r\n      \"texture_url\": \"texture/3d7d5208-a86c-45e2-ac19-733b1492238b.png\",\r\n      \"normal_url\": \"normal/8508b29e-5c9d-43db-8e3d-45f0b94a92bb.png\"\r\n    }\r\n  ]\r\n}";
        test = "{\"user\":\"pkch0102\",\"name\":\"TestProject\",\"version\":1,\"description\":\"테스트용 프로젝트입니다.\",\"img_front_url\":\"\",\"img_left_url\":\"\",\"img_right_url\":\"\",\"img_rear_url\":\"\",\"img_up_url\":\"\",\"blocks\":[{\"rootID\":0,\"ID\":1023701762,\"info_url\":\"info/72fbe06a-b676-43be-88f0-a9dd571d2bd3.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-1506237816,\"info_url\":\"info/123b9f87-a3e6-494f-bc41-089dc1811e10.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-605338906,\"info_url\":\"info/c49e2afd-a931-4971-bd2e-383e210116c2.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-1903451930,\"info_url\":\"info/5636834e-1a79-48bb-94fa-f479f018d63f.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-101654110,\"info_url\":\"info/21076496-008d-43d5-b4c3-59c0bc733678.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":659559964,\"info_url\":\"info/b660a462-22d4-4b5c-8bf5-233ad3ea39ba.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":122802852,\"info_url\":\"info/d78559ac-8c7d-4c03-b7c2-9c1f38ac9a0d.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1056774078,\"info_url\":\"info/653cbeba-d2b9-4dac-8049-da64b78f7877.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1630301292,\"info_url\":\"info/8540ba57-a66c-4183-adc4-28e6f1b1bfc1.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":799244800,\"info_url\":\"info/92640908-5799-4edf-8614-e18408c82d2a.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":295560004,\"info_url\":\"info/63c3e632-7e3d-49a1-ae5f-10e10a5790e5.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1854758254,\"info_url\":\"info/9a1eac9a-d9aa-4326-b38b-c5fd4c3a1cd7.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-932710602,\"info_url\":\"info/d928ca5b-081f-419f-92a7-fd322b6da379.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1093544180,\"info_url\":\"info/dfeb1c37-6e8d-4935-b446-eb8ea67dd2d4.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1957672988,\"info_url\":\"info/6fda5dba-e345-43a5-9e5e-37019654b10c.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":225717586,\"info_url\":\"info/c0949918-3e46-4441-8aa9-0e5364c8ae27.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-638411222,\"info_url\":\"info/84537317-d678-43cf-bfee-1460c83d22df.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1126616496,\"info_url\":\"info/e08c87ba-7d67-4317-a7c4-9286d21bd825.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":729402382,\"info_url\":\"info/b2074dac-36db-45cd-bf2d-ba730f5d7321.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":1924600672,\"info_url\":\"info/6813e206-5c6b-4422-a544-10fb76746ac3.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-1002553020,\"info_url\":\"info/7fb23149-6451-41d9-ba8f-b1ad0659f613.json\",\"texture_url\":\"\",\"normal_url\":\"\"},{\"rootID\":0,\"ID\":-1833609512,\"info_url\":\"info/06636508-5403-4387-b4aa-978d5f82969e.json\",\"texture_url\":\"\",\"normal_url\":\"\"}]}";
        //string str = Encoding.Default.GetString(test);
        ProjectData data = JsonUtility.FromJson<ProjectData>(test);

        DeleteChild(root);
        
        GraphNodes(data);

        List<GameObject> nodeList = new List<GameObject>();
        for (int i = 0; i < nodes.Count; i++)
        {
            GameObject block = Instantiate(cube);
            string json = await DownloadJson(data.blocks[i].info_url);
            BlockHolder blockHolder = block.GetComponent<BlockHolder>();
            blockHolder.FromJson(json);
            if (blockHolder.HasMesh())
            {
                print("data.blocks[i].texture_url " + data.blocks[i].texture_url);
                print("data.blocks[i].normal_url "+ data.blocks[i].normal_url);
                if (data.blocks[i].texture_url != "")
                {
                    Texture2D texture2D = await DownloadTexture(data.blocks[i].texture_url);
                    blockHolder.SetTexture(texture2D);
                }

                if (data.blocks[i].normal_url != "")
                {
                    Texture2D normal = await DownloadTexture(data.blocks[i].normal_url);
                    blockHolder.SetNormal(normal);
                }
            }
            nodeList.Add(block);
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            for(int j = 0; j < nodes[i].Count; j++)
            {
                if (nodes[i][j] == -1)
                    nodeList[i].transform.parent = root.transform;
                else
                {
                    nodeList[i].transform.parent = nodeList[nodes[i][j]].transform;
                }
            }
        }

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

    async Task<string> DownloadJson(string filePath)
    {
        byte[] bytes = await FTPManager.Instance.FtpDownloadJson(filePath);
        return ByteToString(bytes);
    }

    async Task<Texture2D> DownloadTexture(string filePath)
    {
        Texture2D texture = await FTPManager.Instance.FtpDownloadImage(filePath);
        return texture;
    }

    async Task<Texture2D> DownloadNormal(string filePath)
    {
        Texture2D texture = await FTPManager.Instance.FtpDownloadImage(filePath);
        return texture;
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
