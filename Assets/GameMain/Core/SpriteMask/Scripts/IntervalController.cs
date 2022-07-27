using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalController : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public bool IsFollowing = false;
    public LayerMask intervalLayer;
    private Interval currentInterval;
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
                Debug.Log(hitInfo.transform.gameObject.name);
                currentInterval = hitInfo.transform.GetComponent<Interval>();
                if (currentInterval == null)
                {
                    Debug.LogError($"Detected object has no Interval Component.");
                    return;
                }
                IsFollowing = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentInterval = null;
            IsFollowing = false;
        }

        if (IsFollowing)
        {
            if (currentInterval.intervalType == IntervalType.Horizontal)
                currentInterval.transform.position = new Vector2(originPos.x, currentInterval.transform.position.y);
            else
                currentInterval.transform.position = new Vector2(currentInterval.transform.position.x, originPos.y);
        }
    }
}
