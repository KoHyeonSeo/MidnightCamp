using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Text;

public class HTTPManager : MonoBehaviour
{
    public static HTTPManager Instance;

    [NonSerialized] public string id;
    //public string password; // ?
    [NonSerialized] public string accessToken;
    [NonSerialized] public bool isLogin = false;

    HttpClient httpClient = new()
    {
        BaseAddress = new Uri("http://192.168.1.50:8888")
    };

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task GetProjectList(string jsonData)
    {
        using StringContent jsonContent = new(
            jsonData,
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await httpClient.PostAsync("model", jsonContent);

        var jsonResponse = await response.Content.ReadAsStringAsync();
    }

    public async Task Login(string id, string password)
    {
        LoginRequest loginRequest = new LoginRequest();
        loginRequest.id = id;
        loginRequest.password = password;
        string json = JsonUtility.ToJson(loginRequest);

        using StringContent jsonContent = new(
            json,
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await httpClient.PostAsync("auth/login", jsonContent);

        var jsonResponse = await response.Content.ReadAsStringAsync();
        LoginResponse result = JsonUtility.FromJson<LoginResponse>(jsonResponse);
        if (result.success)
        {
            isLogin = true;
            this.id = id;
            accessToken = result.accessToken;
        }
    }

    public async Task UploadProject(string jsonData)
    {
        using StringContent jsonContent = new(
            jsonData,
            Encoding.UTF8,
            "application/json");

        using HttpResponseMessage response = await httpClient.PostAsync("model", jsonContent);

        var jsonResponse = await response.Content.ReadAsStringAsync();
        print(jsonResponse);
        /*LoginResponse result = JsonUtility.FromJson<LoginResponse>(jsonResponse);
        if (result.success)
        {
            isLogin = true;
            this.id = id;
            accessToken = result.accessToken;
        }*/
    }

    async void GetTest()
    {
        //await GetAsync(todoClient);
        await Login("pkch0102", "p010102");
    }
    
    static async Task GetAsync(HttpClient client)
    {
        using HttpResponseMessage response = await client.GetAsync("model");

        print(response.EnsureSuccessStatusCode());

        var jsonResponse = await response.Content.ReadAsStringAsync();
        print($"{jsonResponse}\n");
    }
}
