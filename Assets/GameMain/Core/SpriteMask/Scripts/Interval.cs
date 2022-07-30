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
    public Transform leftEdge, rightEdge;
    private float initOffset, initScaleA, initScaleB;

    private void Start()
    {
        if (intervalType == IntervalType.Horizontal)
        {
            initOffset = this.transform.position.x;
            initScaleA = maskA.transform.localScale.x;
            initScaleB = maskB.transform.localScale.x;
        }

    }

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
