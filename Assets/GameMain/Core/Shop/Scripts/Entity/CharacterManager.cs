using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameKit;

public class CharacterManager : EntityBase
{
    // Update is called once per frame

    [Header("再次互动对话")]
    [SerializeField] protected DialogAsset dialogAssetAfter;
    [Header("互动后回调方法")]
    public UnityEvent onInteract;
    protected override void OnStart()
    {

    }

    public override void OnInteract()
    {
        if (!HasFirstDialoged)
        {
            if (dialogAsset != null)
            {
                dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
                HasFirstDialoged = true;
            }
        }
        else
        {
            if (dialogAssetAfter != null)
            {
                dialogSystem.StartDialog(dialogAssetAfter.title, dialogAssetAfter.contents);
            }
        }
        onInteract?.Invoke();
    }

    private void Update()
    {
        OnUpdate();
    }
}
