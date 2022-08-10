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
    [SerializeField] private EntityBase currentEntity;
    private UI_Bubble uI_Bubble;
    private GameObject currentExit;
    public Animator anim;
    public Vector2 collBoxSize;
    public Vector2 collBoxCenter;
    public LayerMask wallLayer;
    public bool facingRight = true;
    private List<SpriteRenderer> allSpriteRenderers;
    public string currentWorld;
    public Transform camFollowPos;
    public string currentFloor;
    public World startWorld;
    private World currentWorldA, currentWorldB;
    private void Start()
    {
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        uI_Bubble = UIManager.instance.GetUI<UI_Bubble>("UI_Bubble");
        allSpriteRenderers = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
        if (startWorld != null)
        {
            if (startWorld.themeMusic != null) GlobalSound.current.PlayCustomMusicGradually(startWorld.themeMusic, true);
        }
    }
    void Update()
    {

        Vector2 detectCenter = (Vector2)this.transform.position + new Vector2(transform.localScale.x * collBoxCenter.x, collBoxCenter.y);
        horizontal = Input.GetAxisRaw("Horizontal");
        if (!Physics2D.OverlapBox(detectCenter, collBoxSize, 0, wallLayer))
        {
            movement = new Vector3(horizontal * Time.deltaTime * speed, 0, 0);
            anim.SetFloat("Speed", Mathf.Abs(horizontal));
            transform.Translate(movement);
        }
        else
        {
            if ((horizontal > 0 && this.transform.localScale.x < 0) ||
                (horizontal < 0 && this.transform.localScale.x > 0))
            {
                movement = new Vector3(horizontal * Time.deltaTime * speed, 0, 0);
                transform.Translate(movement);
            }
            else
                anim.SetFloat("Speed", 0);
        }


        if (horizontal > 0 && !facingRight) flip();
        if (horizontal < 0 && facingRight) flip();

        uI_Bubble.transform.localScale = new Vector2(Mathf.Sign(transform.localScale.x) * Mathf.Abs(uI_Bubble.transform.localScale.x), uI_Bubble.transform.localScale.y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(currentEntity);
            if (currentEntity != null)
            {
                currentEntity?.OnE();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            EntityBase hitComponent = CursorManager.current.TryGetHitComponent<EntityBase>();
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
        currentEntity = other.GetComponent<EntityBase>();
        if (currentEntity == null || currentWorld != currentEntity.SBelongWorld)
            return;
        currentEntity.OnPassEnter();
        
        if((currentEntity as Item).canCollect)
            uI_Bubble.SetCollective();
        else
            uI_Bubble.SetInteractive();
        
        if (other?.tag == "Wall")
        {
            horizontal *= -1;
        }

        if (other?.gameObject.layer == LayerMask.NameToLayer("Interactive"))
        {
            
            uI_Bubble.Show();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Collective" || other.tag == "Exit" || other.tag == "Character")
        {
            if (currentEntity == null)
                currentEntity = other.GetComponent<EntityBase>();
            if (currentWorld != currentEntity.SBelongWorld)
                return;
            currentEntity?.OnPassExit();
        }
        uI_Bubble.Hide();
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
        uI_Bubble.canvas.sortingLayerName = worldName;
        currentWorld = worldName;
        Debug.Log(currentWorldA + ">>" + currentWorldB);
        if (worldName == "WorldA")
            GlobalSound.current.PlayCustomMusicGradually(currentWorldA?.themeMusic);
        else if (worldName == "WorldB")
            GlobalSound.current.PlayCustomMusicGradually(currentWorldB?.themeMusic);
    }

    public void SetFloor(string FloorName)
    {
        currentFloor = FloorName;
    }

    public void SetWorldSpefic(World World)
    {
        if (World.WorldName == "WorldA")
        {
            currentWorldA = World;
            SetWorld("WorldA");
        }
        else if (World.WorldName == "WorldB")
        {
            currentWorldB = World;
            SetWorld("WorldB");
        }
    }

    public void SwitchWorld(World WorldA, World WorldB)
    {
        currentWorldA = WorldA;
        currentWorldB = WorldB;
        if (allSpriteRenderers.First().sortingLayerName == "WorldA")
        {

            SetWorld("WorldB");
        }
        else if (allSpriteRenderers.First().sortingLayerName == "WorldB")
        {

            SetWorld("WorldA");
        }
    }

    // 临时改变玩家所属层，仅对商场有效，进入商场调用，离开商场调用SetWorld
    public void SetLayerToNone(World world)
    {
        for (int i = 0; i < allSpriteRenderers.Count; i++)
        {
            allSpriteRenderers[i].sortingLayerName = "None";
            allSpriteRenderers[i].maskInteraction = SpriteMaskInteraction.None;
        }
        GlobalSound.current.PlayCustomMusicGradually(world?.themeMusic);
        currentWorld = "None";
    }

    private void OnDrawGizmos()
    {
        Vector2 detectCenter = (Vector2)this.transform.position + new Vector2(transform.localScale.x * collBoxCenter.x, collBoxCenter.y);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(detectCenter, collBoxSize);
    }

    public void SetCamPosY(float yValue)
    {
        camFollowPos.localPosition = new Vector2(camFollowPos.localPosition.x, yValue);
    }
}
