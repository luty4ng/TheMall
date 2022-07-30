using UnityEngine;
using UnityEngine.UI;
using GameKit;
using TMPro;
using UnityEngine.Events;

public class UI_Bubble : UIGroup
{
    private Animator animator;
    protected override void OnStart()
    {
        base.OnStart();
        panelCanvasGroup.alpha = 0f;
        animator = GetComponentInChildren<Animator>();
        Hide();
    }

    public override void Show(UnityAction callback = null)
    {
        if(animator.runtimeAnimatorController!=null)
        {
            animator.SetTrigger("FadeIn");
            return;
        }
        base.Show();
        animator.transform.gameObject.SetActive(true);
    }

    public override void Hide(UnityAction callback = null)
    {
        if(animator.runtimeAnimatorController!=null)
        {
            animator.SetTrigger("FadeOut");
            return;
        }
        base.Hide();
        animator.transform.gameObject.SetActive(false);
    }
}