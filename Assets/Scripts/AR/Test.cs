using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        BlockHolder[] blockHolders = root.GetComponentsInChildren<BlockHolder>();
        foreach (BlockHolder blockHolder in blockHolders)
        {
            blockHolder.transform.localPosition = new Vector3(blockHolder.transform.localPosition.x, 0, blockHolder.transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
