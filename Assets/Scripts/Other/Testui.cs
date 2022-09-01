using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testui : MonoBehaviour
{
    private Text testText;
    private void Start()
    {
        testText = GetComponent<Text>();
    }
    private void Update()
    {
        testText.text = GameManager.instance.curState.ToString();
    }
}
