using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static int NumItem;
    public DialogAsset Dialog;
    void Start()
    {
        NumItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (NumItem == 3) Destroy(this.gameObject);
    }
}
