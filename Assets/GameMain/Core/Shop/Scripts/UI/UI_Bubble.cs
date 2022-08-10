using UnityEngine;
using UnityEngine.UI;
using GameKit;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class UI_Bubble : UIGroup
{
    public Transform Player;
    private Animator animator;
    public Canvas canvas;
    [SerializeField] private Sprite interactive, collective;
    private Sequence sequence;
    [SerializeField] private Image image;
    protected override void OnStart()
    {
        base.OnStart();
        panelCanvasGroup.alpha = 0f;
        animator = GetComponentInChildren<Animator>();
        canvas = GetComponent<Canvas>();
        sequence = DOTween.Sequence();
        Hide();
    }

    private void Update()
    {
        // Vector3 current_pos = this.transform.position;
        // current_pos.x = Player.position.x;
        // this.transform.position = current_pos;
    }
    public override void Show(UnityAction callback = null)
    {
        var current_localScale = this.transform.localScale;
        if (this.transform.localScale.x < 0) this.transform.localScale *= -1;
        this.transform.localScale = current_localScale;
        sequence.Kill();
        sequence.Append(panelCanvasGroup.DOFade(1, 0.3f));
    }

    public override void Hide(UnityAction callback = null)
    {
        sequence.Kill();
        sequence.Append(panelCanvasGroup.DOFade(0, 0.3f));
    }

    public void SetInteractive()
    {
        image.sprite = interactive;
    }

    public void SetCollective()
    {
        image.sprite = collective;
    }
}