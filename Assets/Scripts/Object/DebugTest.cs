using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public GameObject FromObject;
    public GameObject ToObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        
    }

    public void CopyTest()
    {
        BlockHolder[] fromHolders = FromObject.GetComponentsInChildren<BlockHolder>();
        BlockHolder[] Toholders = ToObject.GetComponentsInChildren<BlockHolder>();

        for (int i=0; i<fromHolders.Length; i++)
        {
            Toholders[i].FromJson(fromHolders[i].ToJson());
        }
    }
}
