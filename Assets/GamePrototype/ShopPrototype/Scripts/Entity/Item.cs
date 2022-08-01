using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : EntityBase
{
    public bool hasCollected = false;
    public Sprite itemSprite;
    public string itemName;
    public bool canCloseUp = true;
    public bool hasClicked = false;

    [TextArea(30, 100)] public string itemDesc;
    public override void OnInteract()
    {
        if (!hasClicked)
        {
            if (Input.GetKeyDown(KeyCode.E))
                return;
            dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
            if (canCloseUp) 
            { 
                hasClicked = true;
                Exit.NumItem++;
            };
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (canCloseUp)
                {
                    uI_CloseUp.SetCloseUp(itemSprite, itemName, itemDesc);
                    uI_CloseUp.Show();
                }
                hasCollected = true;
            }
        }
    }

    public override void OnPassExit()
    {
        base.OnPassExit();
        if (hasCollected)
        {
            uI_CloseUp.Hide();
            OnDestroy();
        }
    }
}
