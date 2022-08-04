using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : EntityBase
{
    public Sprite OpenState;
    public bool canOpen = false;

    protected override void OnStart()
    {
        var ChildColliders = this.transform.gameObject.GetComponentsInChildren<BoxCollider2D>();
        for (var i = 1; i < ChildColliders.Length; i++) ChildColliders[i].enabled = false;
    }

    public override void OnInteract()
    {
        if (canOpen)
        {
            this.transform.gameObject.GetComponent<SpriteRenderer>().sprite = OpenState;
            var ChildColliders = this.transform.gameObject.GetComponentsInChildren<BoxCollider2D>();
            foreach (BoxCollider2D Box in ChildColliders) Box.enabled = true;
        }

    }

    private void Update()
    {
        OnUpdate();
    }
}
