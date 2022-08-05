using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class CharacterManager : EntityBase
{
    // Update is called once per frame
    public Sprite changeSprite;

    private void Start()
    {
        switch (this.gameObject.name)
        {
            case "Character_Auntie":
                EventManager.instance.AddEventListener("Auntie's Death", () => 
                {
                    this.GetComponent<SpriteRenderer>().sprite = changeSprite;
                    dialogSystem.StartDialog("AuntieBody's words");
                });
                break;
        }
    }
    public override void OnInteract()
    {
        if (dialogSystem != null) dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
    }

    private void Update()
    {
        OnUpdate();
    }
}
