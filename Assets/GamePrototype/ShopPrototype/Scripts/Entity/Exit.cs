using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : EntityBase
{
    public static int NumItem;
    public UnityEvent onInteract;
    protected override void OnStart()
    {
        base.OnStart();
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
        onInteract?.Invoke();
    }
}
