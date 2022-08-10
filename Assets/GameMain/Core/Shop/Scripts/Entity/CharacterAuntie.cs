using UnityEngine;
using GameKit;

public class CharacterAuntie : CharacterManager
{
    public Sprite DeadAuntieSprite;
    public bool isDead;
    protected override void OnStart()
    {
        base.OnStart();
        EventManager.instance.AddEventListener(EventConfig.AuntieDeath, () =>
                {
                    this.GetComponent<SpriteRenderer>().sprite = DeadAuntieSprite;
                    isDead = true;
                });
    }

    public override void OnInteract()
    {
        if (dialogSystem != null)
        {
            if (!isDead)
                dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
            else
                dialogSystem.StartDialog("AuntieBody's words", CallBack);
        }
        
    }

    public void Aunt_Dead()
    {
        print("Dead");
        isDead = true;
    }

    public void SelfInteractCallback()
    {
        if (isDead)
        {

        }
    }

    private void CallBack()
    {
        onInteract?.Invoke();
    }
}