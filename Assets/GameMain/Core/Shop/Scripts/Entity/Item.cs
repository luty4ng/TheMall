using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameKit;

public class Item : EntityBase
{
    public bool hasCollected = false;
    public Sprite itemSprite;
    public string itemName;
    public bool canCloseUp = true;
    public bool hasClicked = false;
    public bool canChangeSprite = false;
   

    [TextArea(30, 100)] public string itemDesc;

    private void Start()
    {
        switch (this.gameObject.name)
        {
            case "Item_FemaleStatue":
                EventManager.instance.AddEventListener("Model's Door", () =>
                {
                    dialogSystem.StartDialog("Model's words");
                }
                );
                break;
            case "Item_eye":
                EventManager.instance.AddEventListener("Eye1's awaken", () =>  gameObject.SetActive(true));
                break;
            case "Item_eye (1)":
                EventManager.instance.AddEventListener("Eye2's awaken", () => gameObject.SetActive(true));
                break;
            case "Item_eye (2)":
                EventManager.instance.AddEventListener("Eye3's awaken", () => gameObject.SetActive(true));
                break;
            case "Item_Mirror":
                EventManager.instance.AddEventListener("Eye3's awaken", () => gameObject.SetActive(true));
                break;
        }
    }
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

        if (canChangeSprite) this.transform.gameObject.GetComponent<SpriteRenderer>().sprite = itemSprite;
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

    private void Update()
    {
    }

}
