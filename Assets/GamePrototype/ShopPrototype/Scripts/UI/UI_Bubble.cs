using UnityEngine;
using UnityEngine.UI;
using GameKit;
using TMPro;
using UnityEngine.Events;

public class UI_Bubble : UIGroup
{
    public Transform Player;
    private Animator animator;
    protected override void OnStart()
    {
        base.OnStart();
        panelCanvasGroup.alpha = 0f;
        animator = GetComponentInChildren<Animator>();
        Hide();
    }

    private void Update()
    {
        Vector3 current_locale = this.transform.position;
        current_locale.x = Player.position.x;
        this.transform.position = current_locale;
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
        var current_localScale = this.transform.localScale;
        if (this.transform.localScale.x <0) this.transform.localScale*= -1;
        this.transform.localScale = current_localScale;


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