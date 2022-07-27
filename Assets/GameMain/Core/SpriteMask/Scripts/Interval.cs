using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IntervalType
{
    Horizontal,
    Vertical
}
public class Interval : MonoBehaviour
{
    public IntervalType intervalType = IntervalType.Horizontal;
    public Mask maskA, maskB;
    private float initOffset, initScaleA, initScaleB;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        if (intervalType == IntervalType.Horizontal)
        {
            initOffset = this.transform.position.x;
            initScaleA = maskA.transform.localScale.x;
            initScaleB = maskB.transform.localScale.x;
        }

        // if (intervalType == IntervalType.Horizontal)
        // {
        //     initOffset = this.transform.position.x;
        //     float substract = this.transform.position.x - initOffset;
        //     maskA.transform.localScale = new Vector2(maskA.transform.localScale.x + (substract / 10), maskA.transform.localScale.y);
        //     maskB.transform.localScale = new Vector2(maskB.transform.localScale.x - (substract / 10), maskB.transform.localScale.y);
        // }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (intervalType == IntervalType.Horizontal)
        {
            float substract = this.transform.position.x - initOffset;
            maskA.transform.localScale = new Vector2(initScaleA + (substract / 10), maskA.transform.localScale.y);
            maskB.transform.localScale = new Vector2(initScaleB - (substract / 10), maskB.transform.localScale.y);
        }
    }
}
