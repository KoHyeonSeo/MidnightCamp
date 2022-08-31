using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest : MonoBehaviour
{
    public GameObject root;
    public Block[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        //blocks = root.GetComponentsInChildren<Block>();
        /*print(blocks);
        print(JsonUtility.ToJson(blocks));
        foreach (Block block in blocks)
        {
            print(JsonUtility.ToJson(blocks));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
