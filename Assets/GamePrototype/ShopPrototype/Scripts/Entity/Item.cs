using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Collective,
    UnCollective
}

public class Item : EntityBase
{
    public ItemType itemType = ItemType.UnCollective;
    public Sprite itemSprite;
    public string itemName;
    public string itemDesc;
    public override void OnInteract()
    {
        uI_CloseUp.SetCloseUp(itemSprite, itemName, itemDesc);
        if (itemType == ItemType.Collective)
        {
            Collect();
            OnDestroy();
        }
    }

    private void Collect()
    {

    }
}
