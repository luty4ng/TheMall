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
    private Sequence sequence;
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
        Vector3 current_pos = this.transform.position;
        current_pos.x = Player.position.x;
        this.transform.position = current_pos;
    }
    public override void Show(UnityAction callback = null)
    {
        Debug.Log($"Show");
        var current_localScale = this.transform.localScale;
        if (this.transform.localScale.x < 0) this.transform.localScale *= -1;
        this.transform.localScale = current_localScale;
        sequence.Kill();
        sequence.Append(panelCanvasGroup.DOFade(1, 0.3f));
        if (animator.runtimeAnimatorController != null)
        {
            // animator.ResetTrigger("FadeIn");
            animator.SetTrigger("FadeIn");
            return;
        }
        base.Show();
        animator.transform.gameObject.SetActive(true);
    }

    public override void Hide(UnityAction callback = null)
    {
        Debug.Log($"Hide");
        sequence.Kill();
        sequence.Append(panelCanvasGroup.DOFade(0, 0.3f));
        if (animator.runtimeAnimatorController != null)
        {
            // animator.ResetTrigger("FadeOut");
            animator.SetTrigger("FadeOut");
            return;
        }
        base.Hide();
        animator.transform.gameObject.SetActive(false);
    }
}