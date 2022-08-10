using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : EntityBase
{
    public PlayerAgent Player;
    public override void OnInteract()
    {

    }
    public override void OnE()
    {

    }
    private void Update()
    {
        if (Player.currentWorld == this.GetComponent<SpriteRenderer>().sortingLayerName && Player.currentFloor == GetComponentInParent<Floor>().FloorName)
        {
            this.gameObject.layer = 7;
        }
        else this.gameObject.layer = 0;
        OnUpdate();
    }
}
