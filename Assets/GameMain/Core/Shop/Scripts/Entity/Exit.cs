using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : EntityBase
{
    public int NumItem;
    public int NumOfItemToExit = 3;
    [Header("回调：成功离开后")]
    public UnityEvent onInteract;
    public bool Exitable;
<<<<<<< Updated upstream
    public Sprite OpenState;
=======
    public AudioClip Unlock_sound;
    public Sprite openState;
>>>>>>> Stashed changes

    protected override void OnStart()
    {
        base.OnStart();
        NumItem = 0;
    }
    public override void OnInteract()
    {
        SetOpen();
        if (dialogAsset != null)
            dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);

    }

    public override void OnE()
    {
        if (Exitable)
        {
            if (dialogAsset != null)
                dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents, () =>
                {
                    onInteract?.Invoke();
                });
            else
                onInteract?.Invoke();
        }
    }


    public override void OnPassExit()
    {
        // if (NumItem >= NumOfItemToExit || Exitable)
        // {
        //     Debug.Log(dialogSystem.isDialoging);
        //     if (dialogSystem.isDialoging == false) onInteract?.Invoke();
        // }
    }

    public void SetOpen()
    {
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in Obstacles)
        {
            obstacle.GetComponent<Obstacle>().canOpen = true;
        }
    }

    public void EnableExit()
    {
        GameKit.Utility.Debugger.LogSuccess("开启通道");
        Exitable = true;
<<<<<<< Updated upstream
        this.GetComponent<SpriteRenderer>().sprite = OpenState;
=======
        GlobalSound.current.PlaySound("开门声", .4f);
        this.GetComponent<SpriteRenderer>().sprite = openState;
>>>>>>> Stashed changes
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        OnUpdate();
    }
    
}
