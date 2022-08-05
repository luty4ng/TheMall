using UnityEngine;
using GameKit;

public class World : MonoBehaviour
{
    public string WorldName;
    public int RoomId;
    private DialogSystem dialogSystem;
    public DialogAsset dialogAsset;
    private void Start()
    {
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        EntityBase[] entities = GetComponentsInChildren<EntityBase>();
        foreach (var renderer in renderers)
        {
            renderer.sortingLayerName = WorldName;
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