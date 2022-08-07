using UnityEngine;
using GameKit;

[RequireComponent(typeof(BoxCollider2D))]
public class DialogTrigger : MonoBehaviour
{
    [Header("是否一次性")]
    public bool disposable;
    public DialogAsset dialogAsset;
    private BoxCollider2D boxCollider2D;
    private DialogSystem dialogSystem;
    private bool hasTriggered;

    private void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("DialogTrigger");
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        hasTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerDialog();
        }
    }

    public void TriggerDialog()
    {
        if (dialogAsset != null && !hasTriggered)
        {
            dialogSystem.StartDialog(dialogAsset.title, dialogAsset.contents);
            if (disposable)
                hasTriggered = true;
        }

    }
}