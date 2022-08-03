using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : EntityBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void OnInteract()
    {
        if(dialogSystem != null)dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
    }
}
