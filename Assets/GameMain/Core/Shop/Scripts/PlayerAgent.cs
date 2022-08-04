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
    private IInteractive currentEntity;
    private UI_Bubble uI_Bubble;
    private GameObject currentExit;
    public Animator anim;
    private bool facingRight = true;
    private List<SpriteRenderer> allSpriteRenderers;
    private void Start()
    {
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        uI_Bubble = UIManager.instance.GetUI<UI_Bubble>("UI_Bubble");
        allSpriteRenderers = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(horizontal * Time.deltaTime * speed, 0, 0);
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        transform.Translate(movement);
        if (horizontal > 0 && !facingRight) flip();
        if (horizontal < 0 && facingRight) flip();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentEntity != null)
            {
                currentEntity?.OnInteract();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            IInteractive hitComponent = CursorManager.current.TryGetHitComponent<IInteractive>();
            var temp = CursorManager.current.TryGetHitComponent<IInteractive>();
            if (hitComponent != null)
            {
                hitComponent?.OnInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other?.tag == "Collective")
        {
            currentEntity = other.GetComponent<IInteractive>();
            currentEntity.OnPassEnter();
            if (other.transform.GetComponent<Item>().hasClicked) uI_Bubble.Show();
        }
        if (other?.tag == "Exit" || other?.tag == "Character")
        {
            currentEntity = other.GetComponent<IInteractive>();
            currentEntity.OnPassEnter();
            uI_Bubble.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Collective" || other.tag == "Exit" || other.tag == "Character")
        {
            if (currentEntity == null)
                currentEntity = other.GetComponent<IInteractive>();
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
        }
    }


    public void SwitchWorld()
    {
        if (allSpriteRenderers.First().sortingLayerName == "WorldA")
            SetWorld("WorldB");
        else if (allSpriteRenderers.First().sortingLayerName == "WorldB")
            SetWorld("WorldA");
    }
}
