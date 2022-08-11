using UnityEngine;

public class CharacterKid : CharacterManager
{
    public DialogAsset AfterFind;
    public GameObject hint;
    public override void OnInteract()
    {
        if (floor.exitCondition.NumItem >= floor.exitCondition.NumOfItemToExit)
        {
            floor.exitCondition.Exitable = true;
            if (dialogAsset != null && AfterFind != null)
            {
                this.gameObject.SetActive(false);
                hint.SetActive(true);
                dialogSystem.StartDialog(AfterFind.title, AfterFind.contents);

            }
                
        }
        else
        {
            if (dialogAsset != null)
                dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
        }
        onInteract?.Invoke();
        
    }

}