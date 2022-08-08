using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using System.Linq;

public class PlayerAgent : MonoBehaviour
{
    public const string PASSENTER_EVENT = "Player Pass Enter";
    public const string PASSEXIT_EVENT = "Player Pass Exit";
    public float speed = 10;
    private float horizontal;
    private Vector3 movement;
    private DialogSystem dialogSystem;
    [SerializeField] private IInteractive currentEntity;
    private UI_Bubble uI_Bubble;
    private GameObject currentExit;
    public Animator anim;
    public Vector2 collBoxSize;
    public Vector2 collBoxCenter;
    public LayerMask wallLayer;
    public bool facingRight = true;
    private List<SpriteRenderer> allSpriteRenderers;
    public string currentWorld;
    private void Start()
    {
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        uI_Bubble = UIManager.instance.GetUI<UI_Bubble>("UI_Bubble");
        allSpriteRenderers = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
    }
    void Update()
    {
        Vector2 detectCenter = (Vector2)this.transform.position + new Vector2(transform.localScale.x * collBoxCenter.x, collBoxCenter.y);
        if (Physics2D.OverlapBox(detectCenter, collBoxSize, 0, wallLayer))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            movement = new Vector3(horizontal * Time.deltaTime * speed, 0, 0);
            anim.SetFloat("Speed", Mathf.Abs(horizontal));
            transform.Translate(movement);
        }
        if (horizontal > 0 && !facingRight) flip();
        if (horizontal < 0 && facingRight) flip();
        horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(horizontal * Time.deltaTime * speed, 0, 0);
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        transform.Translate(movement);
        if (horizontal > 0 && !facingRight) flip();
        if (horizontal < 0 && facingRight) flip();

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(currentEntity);
            if (currentEntity != null)
            {
                currentEntity?.OnInteract();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            IInteractive hitComponent = CursorManager.current.TryGetHitComponent<IInteractive>();
            GameObject hitObject = CursorManager.current.TryGetHitGameObject();
            if (hitComponent != null)
            {
                if ((currentWorld == hitComponent.SBelongWorld || currentWorld == "None"))
                    hitComponent?.OnInteract();
            }
        }

        //switch (currentWorld.RoomId)
        // {
        // case World.Room_Name.
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other?.tag == "Collective")
        {
            currentEntity = other.GetComponent<IInteractive>();
            if (currentEntity == null || currentWorld != currentEntity.SBelongWorld)
                return;
            currentEntity.OnPassEnter();
            if (other.transform.GetComponent<Item>().hasClicked) uI_Bubble.Show();
        }
        if (other?.tag == "Exit" || other?.tag == "Character")
        {
            currentEntity = other.GetComponent<IInteractive>();
            if (currentEntity == null || currentWorld != currentEntity.SBelongWorld)
                return;
            currentEntity.OnPassEnter();
            uI_Bubble.Show();
        }
        if (other?.tag == "Wall")
        {
            horizontal *= -1;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Collective" || other.tag == "Exit" || other.tag == "Character")
        {
            if (currentEntity == null)
                currentEntity = other.GetComponent<IInteractive>();
            if (currentWorld != currentEntity.SBelongWorld)
                return;
            currentEntity?.OnPassExit();
            uI_Bubble.Hide();
        }
    }

    void flip()
    {
        Vector3 currentScale = this.gameObject.transform.localScale;
        currentScale.x *= -1;
        this.gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void SetWorld(string worldName)
    {
        for (int i = 0; i < allSpriteRenderers.Count; i++)
        {
            allSpriteRenderers[i].sortingLayerName = worldName;
            allSpriteRenderers[i].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
        currentWorld = worldName;
    }


    public void SwitchWorld(string WorldAName, string WorldBName)
    {
        if (allSpriteRenderers.First().sortingLayerName == "WorldA")
            SetWorld("WorldB");
        else if (allSpriteRenderers.First().sortingLayerName == "WorldB")
            SetWorld("WorldA");
    }

    // 临时改变玩家所属层，仅对商场有效，进入商场调用，离开商场调用SetWorld
    public void SetLayerToNone()
    {
        for (int i = 0; i < allSpriteRenderers.Count; i++)
        {
            allSpriteRenderers[i].sortingLayerName = "None";
            allSpriteRenderers[i].maskInteraction = SpriteMaskInteraction.None;
        }
        currentWorld = "None";
    }

    private void OnDrawGizmos()
    {
        Vector2 detectCenter = (Vector2)this.transform.position + new Vector2(transform.localScale.x * collBoxCenter.x, collBoxCenter.y);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(detectCenter, collBoxSize);
    }
}
