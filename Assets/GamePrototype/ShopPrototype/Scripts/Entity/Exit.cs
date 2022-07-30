using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : EntityBase
{
    public static int NumItem;
    public UnityEvent OnEnterExit;
    public DialogAsset Dialog;
    void Start()
    {
        NumItem = 0;
    }

    void Update()
    {
        if (NumItem == 3) Destroy(this.gameObject);
    }

    public override void OnInteract()
    {
        if (dialogAsset != null)
            dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
    }
}
