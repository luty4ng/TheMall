using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : EntityBase
{
    public static int NumItem;
    public UnityEvent onInteract;
    public DialogAsset Response;
    protected override void OnStart()
    {
        base.OnStart();
        NumItem = 0;
    }

    void Update()
    {
    }

    public override void OnInteract()
    {
        if (dialogAsset != null)
            dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
        if (NumItem == 3)
        {
            Debug.Log(dialogSystem.isDialoging);
            if (dialogAsset != null)dialogSystem.StartDialog(Response.title, Response.contents);
            if(dialogSystem.isDialoging == false)onInteract?.Invoke();
        }
    }
}
