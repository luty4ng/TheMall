using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameKit;
using GameKit.Timer;
using DG.Tweening;

public class MenuInterval : MonoBehaviour
{
    public Transform betweening;
    public Mask maskA, maskB;
    public Transform leftEdge, rightEdge;
    public bool IsTravelActive = true;
    public bool isMoving;
    private float initOffset, initScaleA, initScaleB;
    private SpriteRenderer mySpriteRenderer;
    private float activateDistanceOffset = 2f;
    private float activateTime = 2f;
    public UnityEvent OnAligned;
    private bool hasTriggered;
    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        initOffset = this.transform.position.x;
        initScaleA = maskA.transform.localScale.x;
        initScaleB = maskB.transform.localScale.x;
        isMoving = false;
        hasTriggered = false;
    }

    private void Update()
    {

        float substract = this.transform.position.x - initOffset;
        maskA.transform.localScale = new Vector2(initScaleA + (substract / 10.2f), maskA.transform.localScale.y);
        maskB.transform.localScale = new Vector2(initScaleB - (substract / 10.2f), maskB.transform.localScale.y);

        if (betweening == null)
            return;

        float disToJuncture = Mathf.Abs(betweening.position.x - this.transform.position.x);
        if (IsTravelActive && disToJuncture < activateDistanceOffset)
        {
            if (!hasTriggered)
            {
                StartCoroutine(DoUnityEvent(activateTime));
                hasTriggered = true;
            }
        }
        else
        {
            hasTriggered = false;
        }

        if (isMoving)
        {
            float volume = Mathf.Clamp(5 / disToJuncture, 0.1f, 1f);
            //GlobalSound.current.PlaySound("女性笑声", volume);
        }
    }

    IEnumerator DoUnityEvent(float timer)
    {
        yield return new WaitForSeconds(timer);
        OnAligned?.Invoke();
    }
}
