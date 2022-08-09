using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIntervalController : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public bool IsFollowing = false;
    public LayerMask intervalLayer;
    private MenuInterval currentInterval;
    private void Start()
    {
        IsFollowing = false;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        Vector3 originPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diretcion = Camera.main.transform.forward;
        if (Input.GetMouseButton(0))
        {
            // Debug.Log(originPos);
            RaycastHit2D hitInfo = Physics2D.Raycast(originPos, diretcion, 10, intervalLayer);
            if (hitInfo)
            {
                currentInterval = hitInfo.transform.GetComponent<MenuInterval>();
                if (currentInterval == null)
                {
                    Debug.LogError($"Detected object has no Interval Component.");
                    return;
                }
                currentInterval.isMoving = true;
                IsFollowing = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (currentInterval != null) currentInterval.isMoving = false;
            currentInterval = null;
            IsFollowing = false;
        }

        if (IsFollowing)
        {
            if (originPos.x < currentInterval.rightEdge.position.x && originPos.x > currentInterval.leftEdge.position.x)
                currentInterval.transform.position = new Vector2(originPos.x, currentInterval.transform.position.y);
        }
    }
}
