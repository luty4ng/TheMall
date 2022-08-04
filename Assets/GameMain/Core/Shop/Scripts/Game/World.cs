using UnityEngine;

public class World : MonoBehaviour
{
    public string WorldName;
    public int RoomId;
    private void Start()
    {
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
    public enum RoomNum
    {
        room1 = 1,
        room2 = 2
    }
}