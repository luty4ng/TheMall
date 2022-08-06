using UnityEngine;
using GameKit;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class EntityBase : MonoBehaviour, IInteractive
{
    protected UI_CloseUp uI_CloseUp;
    protected DialogSystem dialogSystem;
    [Header("第一次互动对话")]
    [SerializeField] protected DialogAsset dialogAsset;
    private string m_Name;
    [Header("物品所属世界，由World脚本自动设置，商场的都是None")]
    public string BelongWorld = "None";
    [HideInInspector] public BoxCollider2D boxCollider2D;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    protected Floor floor;
    protected Interval interval;
    public string Name
    {
        get
        {
            return m_Name;
        }
    }

    public string SBelongWorld
    {
        get
        {
            return BelongWorld;
        }
    }

    private void Start()
    {
        // EntityManager.instance.Register(this);
        uI_CloseUp = UIManager.instance.GetUI<UI_CloseUp>("UI_CloseUp");
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (boxCollider2D == null)
            boxCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // boxCollider2D.gameObject.layer = 
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

    public virtual void OnUpdate()
    {
        if (BelongWorld == "None")
        {
            // Utility.Debugger.LogFail("Entity {0} Set Wolrd Incorrect.", this.name);
            return;
        }
        float signDistance = this.transform.position.x - interval.transform.position.x;

        if (boxCollider2D == null)
            return;

        if (BelongWorld == "WorldA")
        {
            boxCollider2D.enabled = signDistance > 0 ? false : true;
        }
        else if (BelongWorld == "WorldB")
        {
            boxCollider2D.enabled = signDistance < 0 ? false : true;
        }
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
        if (this != null && this.gameObject != null)
            Destroy(this.gameObject);
    }

    public abstract void OnInteract();
    public void SetFloor(Floor newFloor)
    {
        this.floor = newFloor;
        interval = floor.Interval;

    }
}