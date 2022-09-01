using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMobile : MonoBehaviour
{
    [SerializeField] InputField idInput;
    [SerializeField] InputField PasswordInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async void OnClickButton()
    {
        await HTTPManager.Instance.Login(idInput.text, PasswordInput.text);
        if (HTTPManager.Instance.isLogin)
        {
            print("성공");
            SceneManager.LoadScene("MobileMainScene");
        }
        else
        {
            print("실패");
        }
    }
}
