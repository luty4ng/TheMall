using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;
using GameKit.Timer;
using DG.Tweening;

public enum IntervalType
{
    Horizontal,
    Vertical
}
public class Interval : MonoBehaviour
{
    public Transform betweening;
    public IntervalType intervalType = IntervalType.Horizontal;
    public Mask maskA, maskB;
    public Transform leftEdge, rightEdge;
    public bool CanTravel = false;
    public bool IsTravelActive = true;
    private float initOffset, initScaleA, initScaleB;
    private SpriteRenderer mySpriteRenderer;
    private Ticker_Auto ticker;
    [SerializeField] private float activateTime = 2f;
    [SerializeField] private float activateDistanceOffset = 2.5f;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        ticker = new Ticker_Auto(activateTime);
        ticker.Register(EnableTravel);
        ticker.Start();
        ticker.Pause();

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
            if (betweening == null)
                return;

            float disToJuncture = Mathf.Abs(betweening.position.x - this.transform.position.x);
            if (IsTravelActive && disToJuncture < activateDistanceOffset)
            {
                ticker.Resume();
            }
            else
            {
                ticker.Pause();

                // 如果玩家已经穿越过了Inverval， 则需要移开Interval来重新激活可穿越特性
                if (!IsTravelActive && disToJuncture >= activateDistanceOffset)
                    IsTravelActive = true;

                // 如果玩家没穿过Inverval就移动了Inverval， 则恢复原状并关闭穿越性质
                if(CanTravel)
                {
                    CanTravel = false;
                    this.transform.DOScaleX(2f, 0.1f).SetEase(Ease.Flash);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float playerX = other.gameObject.transform.position.x;
            float intervalX = this.transform.position.x;
            if (CanTravel && Mathf.Abs(playerX - intervalX) <= 0.1f)
            {
                other.GetComponent<PlayerAgent>().SwitchWorld();
                CanTravel = false;
                IsTravelActive = false;
                this.transform.DOScaleX(2f, 0.1f).SetEase(Ease.Flash);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

    private void EnableTravel()
    {
        Utility.Debugger.LogWarning("EnableTravel");
        CanTravel = true;
        this.transform.DOScaleX(0.5f, 0.1f).SetEase(Ease.InOutBounce);
    }
}
