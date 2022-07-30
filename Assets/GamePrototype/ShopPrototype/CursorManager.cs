using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWolrdPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    private DialogSystem dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
    private bool Clickable;
    private void Update()
    {
        Clickable = ObjectAtMousePosition();

        if (Clickable && Input.GetMouseButtonDown(0)) 
        {
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void ClickAction(GameObject clickObject) 
    {
        var temp = clickObject.GetComponent<Item>();
        switch (clickObject.tag) 
        {
            case "Window":
                clickObject.SetActive(false);
                break;
            case "Collective":
                //Not null
                dialogSystem.StartDialog(temp.Dialog.title, temp.Dialog.contents);
                temp.Collectable = true;
                break;
            case "Uncollective":
                dialogSystem?.StartDialog(temp.Dialog.title, temp.Dialog.contents);
                break;
        }
    }

    private Collider2D ObjectAtMousePosition() 
    {
        return Physics2D.OverlapPoint(mouseWolrdPos);
    }
}
