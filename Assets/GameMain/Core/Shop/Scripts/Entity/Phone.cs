using UnityEngine;

public class Phone : Item
{
    [SerializeField] private bool hasRing = false;

    public override void OnInteract()
    {
        base.OnInteract();
    }

    public void Ring()
    {
        hasRing = true;
        GlobalSound.current.PlaySound("电话铃声", 0.5f,true);
        // Ring
    }

    public void StopRing()
    {
        hasRing = false;
        GlobalSound.current.StopSound("电话铃声");
    }
}