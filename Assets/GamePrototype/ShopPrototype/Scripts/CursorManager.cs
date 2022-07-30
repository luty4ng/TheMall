using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class CursorManager : MonoSingletonBase<CursorManager>
{
    public static Vector3 MAGIC_VECTOR = Vector3.zero;
    public RaycastHit hitInfo;
    public LayerMask interactiveLayer;


    private void Update()
    {
        if (IsActive)
        {
            Vector3 originPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 diretcion = Camera.main.transform.forward;
            if (Physics.Raycast(originPos, diretcion, out RaycastHit hitInfo, 20, interactiveLayer))
                this.hitInfo = hitInfo;
        }
    }

    public Vector3 TryGetHitPosition()
    {
        if (!IsActive || hitInfo.transform == null || hitInfo.transform.gameObject == null)
        {
            Utility.Debugger.LogWarning("No Hit Target Exsit.");
            return MAGIC_VECTOR;
        }
        return this.hitInfo.point;
    }

    public GameObject TryGetHitGameObject()
    {
        if (!IsActive || hitInfo.transform == null || hitInfo.transform.gameObject == null)
        {
            Utility.Debugger.LogWarning("No Hit Target Exsit.");
            return null;
        }
        return this.hitInfo.transform.gameObject;
    }

    public T TryGetHitComponent<T>() where T : class
    {
        if (!IsActive || hitInfo.transform == null || hitInfo.transform.gameObject == null)
        {
            Utility.Debugger.LogWarning("No Hit Target Exsit.");
            return null;
        }
        T component = hitInfo.transform.GetComponent<T>();
        if (component == null)
        {
            Utility.Debugger.LogWarning(Utility.Text.Format("Hit Target Has No {0} Component.", typeof(T).Name));
            return null;
        }
        return component;
    }
    
    
    // private Vector3 mouseWolrdPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    // private DialogSystem dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
    // private bool Clickable;
    // private void Update()
    // {
    //     Clickable = ObjectAtMousePosition();

    //     if (Clickable && Input.GetMouseButtonDown(0)) 
    //     {
    //         ClickAction(ObjectAtMousePosition().gameObject);
    //     }
    // }

    // private void ClickAction(GameObject clickObject) 
    // {
    //     var temp = clickObject.GetComponent<Item>();
    //     switch (clickObject.tag) 
    //     {
    //         case "Window":
    //             clickObject.SetActive(false);
    //             break;
    //         case "Collective":
    //             //Not null
    //             dialogSystem.StartDialog(temp.Dialog.title, temp.Dialog.contents);
    //             temp.Collectable = true;
    //             break;
    //         case "Uncollective":
    //             dialogSystem?.StartDialog(temp.Dialog.title, temp.Dialog.contents);
    //             break;
    //     }
    // }

    // private Collider2D ObjectAtMousePosition() 
    // {
    //     return Physics2D.OverlapPoint(mouseWolrdPos);
    // }
}
