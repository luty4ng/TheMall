using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class CursorManager : MonoSingletonBase<CursorManager>
{
    public static Vector3 MAGIC_VECTOR = Vector3.zero;
    public RaycastHit2D hitInfo;
    public LayerMask interactiveLayer;
    private Vector3 originPos;
    private Vector3 diretcion;
    public Texture2D point, select, questionMark;
    private void Start()
    {
        Cursor.SetCursor(point, new Vector2(16, 16), CursorMode.Auto);
        Enable();
    }

    private void Update()
    {
        if (IsActive)
        {
            originPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            diretcion = Camera.main.transform.forward;
            this.hitInfo = Physics2D.Raycast(originPos, diretcion, 10, interactiveLayer);
            if(hitInfo.collider != null)
            {
                Cursor.SetCursor(questionMark, new Vector2(16, 16), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(point, new Vector2(16, 16), CursorMode.Auto);
            }
        }
        if (Input.GetMouseButtonDown(0)) Cursor.SetCursor(select, new Vector2(16, 16), CursorMode.Auto);
        else if (Input.GetMouseButtonUp(0)) Cursor.SetCursor(point, new Vector2(16, 16), CursorMode.Auto);
    }

    public Vector3 TryGetHitPosition()
    {
        if (!IsActive || hitInfo.transform == null || hitInfo.transform.gameObject == null)
        {
            // Utility.Debugger.LogWarning("No Hit Target Exsit.");
            return MAGIC_VECTOR;
        }
        return this.hitInfo.point;
    }

    public GameObject TryGetHitGameObject()
    {
        if (!IsActive || hitInfo.transform == null || hitInfo.transform.gameObject == null)
        {
            // Utility.Debugger.LogWarning("No Hit Target Exsit.");
            return null;
        }
        return this.hitInfo.transform.gameObject;
    }

    public T TryGetHitComponent<T>() where T : class
    {
        if (!IsActive)
        {
            Utility.Debugger.LogWarning("CursorSystem Is Not Activate.");
            return null;
        }

        if (hitInfo.transform == null || hitInfo.transform.gameObject == null)
        {
            // Utility.Debugger.LogWarning("No Hit Target Exsit.");
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

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {

            if (hitInfo.transform != null)
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.red;
            Gizmos.DrawLine(originPos, originPos + diretcion * 40);
        }
    }
}
