using UnityEngine;
using GameKit;

public abstract class EntityBase : MonoBehaviour, IInteractive
{
    protected UI_CloseUp uI_CloseUp;
    protected DialogSystem dialogSystem;
    [SerializeField] protected DialogAsset dialogAsset;
    private string m_Name;
    public string Name
    {
        get
        {
            return m_Name;
        }
    }

    private void Start()
    {
        // EntityManager.instance.Register(this);
        uI_CloseUp = UIManager.instance.GetUI<UI_CloseUp>("UI_CloseUp");
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        OnStart();
    }

    protected virtual void OnStart() { }
    public virtual void OnInit()
    {
        // 注册后的初始化
    }

    public virtual void OnHover()
    {
        // 2D 高亮Outline 有待实现
    }

    public virtual void OnPassEnter()
    {
        EventManager.instance.EventTrigger(PlayerAgent.PASSENTER_EVENT);
    }

    public virtual void OnPassExit()
    {
        EventManager.instance.EventTrigger(PlayerAgent.PASSEXIT_EVENT);
    }

    public virtual void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    public abstract void OnInteract();
}