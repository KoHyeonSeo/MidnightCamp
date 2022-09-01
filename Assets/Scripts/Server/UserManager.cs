using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Threading.Tasks;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;

    public string id;
    //public string password; // ?
    public string accessToken;
    public bool isLogin = false;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public struct LoginRequest
    {
        public string id;
        public string password;
    }

    [System.Serializable]
    public struct LoginResponse
    {
        public bool success;
        public string accessToken;
    }

    // Start is called before the first frame update
    void Start()
    {
        Login("pkch0102", "p010102");
        print("id: " + id + " token: " + accessToken);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login(string id, string password)
    {
        string uri = "http://192.168.1.51:8888/auth/login";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.Method = "POST";
        request.ContentType = "application/json;";

        using (var streamWriter = new StreamWriter(request.GetRequestStream())) //전송
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.id = id;
            loginRequest.password = password;
            JsonUtility.ToJson(loginRequest);
            string json = "{ \"id\": \""+id + "\",\"password\" : \"" + password+"\"}";
            json = JsonUtility.ToJson(loginRequest);
            streamWriter.Write(json);
        }

        var response = (HttpWebResponse)request.GetResponse(); //응답
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            string apiResult = streamReader.ReadToEnd();
            LoginResponse result = JsonUtility.FromJson<LoginResponse>(apiResult);

            if (result.success)
            {
                isLogin = true;
                this.id = id;
                accessToken = result.accessToken;
            }
        }
    }
}
