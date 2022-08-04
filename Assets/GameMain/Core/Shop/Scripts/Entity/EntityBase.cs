using UnityEngine;
using GameKit;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class EntityBase : MonoBehaviour, IInteractive
{
    [SerializeField] protected UI_CloseUp uI_CloseUp;
    [SerializeField] protected DialogSystem dialogSystem;
    [SerializeField] protected DialogAsset dialogAsset;
    private string m_Name;
    public string BelongWorld = "None";
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Floor floor;
    [SerializeField] private Interval interval;
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
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (boxCollider2D == null)
            boxCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
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
            Utility.Debugger.LogFail("Entity {0} Set Wolrd Incorrect.", this.name);
            return;
        }
        float signDistance = this.transform.position.x - interval.transform.position.x;

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
        Destroy(this.gameObject);
    }

    public abstract void OnInteract();
    public void SetFloor(Floor newFloor)
    {
        this.floor = newFloor;
        interval = floor.Interval;

    }
}