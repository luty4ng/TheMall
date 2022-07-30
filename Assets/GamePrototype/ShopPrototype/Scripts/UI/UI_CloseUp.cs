using UnityEngine;
using UnityEngine.UI;
using GameKit;
using TMPro;
using UnityEngine.Events;
public class UI_CloseUp : UIGroup
{
    private Animator animator;
    public Image closeUpImage;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    protected override void OnStart()
    {
        base.OnStart();
        panelCanvasGroup.alpha = 0f;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }

    public void SetCloseUp(Sprite sprite, string name, string desc)
    {
        closeUpImage.sprite = sprite;
        Name.text = name;
        Description.text = desc;
    }

    public override void Show(UnityAction callback = null)
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("FadeIn");
            animator.OnComplete(1f, callback);
            return;
        }
        base.Show();
        animator.transform.gameObject.SetActive(true);
        callback?.Invoke();
    }

    public override void Hide(UnityAction callback = null)
    {
        if (animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("FadeOut");
            animator.OnComplete(1f, callback);
            return;
        }
        base.Hide();
        animator.transform.gameObject.SetActive(false);
        callback?.Invoke();
    }
}