using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class StartDialog : MonoBehaviour
{
    public DialogAsset dialogAsset;
    DialogSystem dialogSystem;
    private void Start()
    {
         dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
    }

    public void startDialog()
    {
        dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
    }

}
