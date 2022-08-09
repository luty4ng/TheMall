using UnityEngine;
using GameKit;
using UnityEngine.Events;
using System.Collections;

public class MenuWorld : MonoBehaviour
{
    public string WorldName;
    private SpriteRenderer[] renderers;
    private void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        EntityBase[] entities = GetComponentsInChildren<EntityBase>();
        foreach (var renderer in renderers)
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
            

            for (int i = 0; i < entities.Length; i++)
            {
                entities[i].BelongWorld = WorldName;
            }
        }
    }
}