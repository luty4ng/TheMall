using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : EntityBase
{
    public Sprite OpenState;
    public override void OnInteract()
    {
        this.transform.gameObject.GetComponent<SpriteRenderer>().sprite = OpenState;
        this.transform.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
