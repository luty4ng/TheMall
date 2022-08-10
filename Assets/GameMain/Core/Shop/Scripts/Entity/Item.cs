using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameKit;
using UnityEngine.Events;

public class Item : EntityBase
{
    [Header("如果拥有特写，这里拖入特写画面，否则默认SpriteRenderer的图像")]
    public Sprite closeUpSprite;
    [Header("是否拥有特写")]
    public bool canCloseUp = true;
    [Header("是否可收集")]
    public bool canCollect = true;
    [Header("第一次点击互动后的回调方法")]
    public UnityEvent AfterFirstInteract;
    [Header("收集后的回调方法")]
    public UnityEvent AfterCollect;
    public string itemName;
    [TextArea(15, 100)] public string itemDesc;
    [HideInInspector] public bool hasClicked = false;
    private bool hasCollected = false;


    protected override void OnStart()
    {
        base.OnStart();
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
                EventManager.instance.AddEventListener("Eye1's awaken", () => gameObject.SetActive(true));
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
            hasClicked = true;
            AfterFirstInteract?.Invoke();

            if (dialogAsset != null)
                dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
        }
    }

    public override void OnE()
    {
        if (canCollect)
        {
            if (floor.exitCondition != null)
                floor.exitCondition.NumItem++;

            if (canCloseUp)
            {
                Sprite sprite = closeUpSprite == null ? spriteRenderer.sprite : closeUpSprite;
                uI_CloseUp.SetCloseUp(sprite, itemName, itemDesc);
                uI_CloseUp.Show();
            }
        }
        hasCollected = true;
    }

    public override void OnPassExit()
    {
        base.OnPassExit();
        if (hasCollected)
        {
            uI_CloseUp.Hide();
            if (canCollect)
            {
                AfterCollect?.Invoke();
                OnDestroy();
            }
        }
    }

    private void Update()
    {
        OnUpdate();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (hasCollected)
            {
                uI_CloseUp.Hide();
                if (canCollect)
                {
                    AfterCollect?.Invoke();
                    OnDestroy();
                }
            }
        }
    }

}
