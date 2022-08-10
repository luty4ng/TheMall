using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : EntityBase
{
    public Transform ImagTrans;
    public bool canOpen = true;
    [SerializeField] Item[] coverItem;

    protected override void OnStart()
    {
        base.OnStart();
        coverItem = this.transform.gameObject.GetComponentsInChildren<Item>();
        StartCoroutine(ExecuteNextFrame());
    }


    IEnumerator ExecuteNextFrame()
    {
        yield return null;
        for (var i = 0; i < coverItem.Length; i++)
        {
            coverItem[i].BelongWorld = "None";
            coverItem[i].boxCollider2D.enabled = false;
        }
    }

    public override void OnInteract()
    {
        if (canOpen)
        {
            GlobalSound.current.PlaySound("卷帘门拉开", 0.5f,false);
            ImagTrans.DOMoveY(ImagTrans.position.y + 10, 0.5f);
            coverItem = this.transform.gameObject.GetComponentsInChildren<Item>();
            for (var i = 0; i < coverItem.Length; i++)
            {
                coverItem[i].boxCollider2D.enabled = true;
                coverItem[i].spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
                coverItem[i].spriteRenderer.sortingLayerName = "WorldA";
            }
            if (dialogAsset != null) dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
            boxCollider2D.enabled = false;
        }
    }

    public override void OnE()
    {

    }

    private void Update()
    {
        OnUpdate();
    }
}
