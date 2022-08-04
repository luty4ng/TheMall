using UnityEngine;

public class WorldA : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.sortingLayerName = "WorldA";
            if (renderer.gameObject.name == "BKG")
            {
                renderer.sortingOrder = -1;
            }
            else if(renderer.gameObject.name == "Player")
            {
                renderer.sortingOrder = 1;
            }
            else
            {
                renderer.sortingOrder = 0;
            }
        }
    }
    public enum RoomNum
    {
        room1= 1,
        room2 = 2
    }
}