using UnityEngine;
using GameKit;
using UnityEngine.Events;
using System.Collections;

public class World : MonoBehaviour
{
    public string WorldName;
    public int RoomId;
    private DialogSystem dialogSystem;
    private SpriteRenderer[] renderers;
    public bool IsSettable = true;
    public UnityEvent EnterEvent;
    private PlayerAgent player;
    private bool hasExecuted;
    public bool Immediate = false;
    private void Start()
    {
        hasExecuted = false;
        player = GameObject.Find("Player (1)").GetComponent<PlayerAgent>();
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
        EntityBase[] entities = GetComponentsInChildren<EntityBase>();
        foreach (var renderer in renderers)
        {
            if (IsSettable)
            {
                renderer.sortingLayerName = WorldName;
                renderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                if (renderer.gameObject.name == "BKG")
                {
                    renderer.sortingOrder = -1;
                }
                else if (renderer.gameObject.name == "Player")
                {
                    renderer.sortingOrder = 1;
                }
                else
                {
                    renderer.sortingOrder = 0;
                }
            }

            for (int i = 0; i < entities.Length; i++)
            {
                entities[i].BelongWorld = WorldName;
            }
        }
    }
    private void Update()
    {
        if (hasExecuted) return;
        if (player.currentWorld == this.WorldName && player.currentFloor == GetComponentInParent<Floor>().FloorName)
        {
            StartCoroutine(EventTrigger(500));
        }
    }

    IEnumerator EventTrigger(float duration)
    {
        if(!Immediate)yield return new WaitForSeconds(duration * Time.deltaTime);
            EnterEvent?.Invoke();
            hasExecuted = true;
    }
}