using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : EntityBase
{
    public bool hasCollected = false;
    public Sprite itemSprite;
    public string itemName;
    [TextArea(30, 100)] public string itemDesc;
    public override void OnInteract()
    {
        uI_CloseUp.SetCloseUp(itemSprite, itemName, itemDesc);
        uI_CloseUp.Show();
        hasCollected = true;
    }

    public override void OnPassExit()
    {
        base.OnPassExit();
        if (hasCollected)
        {
            uI_CloseUp.Hide(Dialog);
            OnDestroy();
        }
    }

    private void Dialog()
    {
        if (dialogAsset != null)
        {
            dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
        }
    }
}
