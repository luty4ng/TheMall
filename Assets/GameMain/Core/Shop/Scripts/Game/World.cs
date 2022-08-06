using UnityEngine;
using GameKit;

public class World : MonoBehaviour
{
    public string WorldName;
    public int RoomId;
    private DialogSystem dialogSystem;
    private SpriteRenderer[] renderers;
    public bool IsSettable = true;
    private void Start()
    {
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
    public enum Room_Name
    {
        Hallway = 1,
        Director = 2,
        Shop = 3,
        Orphanage = 4,
        MainCafe = 5,
        Storage = 6,
        Basement = 7,
        Secret = 8
    }
}