using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using GameKit;
using GameKit.DataStructure;
using System.Linq;
using UnityEngine.Events;

public class UI_Recorder : UIGroup
{
    [Header("Reference")]
    public RectTransform content;
    public RectTransform record;
    public TextMeshProUGUI textLine_Prototype;
    private AdaptiveSize_UI adaptiveUI;
    private Animator animator;

    [Header("Settings")]
    public int maxNumberOfLines = 50;
    private List<TextMeshProUGUI> lines;
    protected override void OnStart()
    {
        base.OnStart();
        adaptiveUI = GetComponentInChildren<AdaptiveSize_UI>();
        animator = GetComponent<Animator>();
        adaptiveUI.maxHeight = maxNumberOfLines;
        lines = new List<TextMeshProUGUI>();
        IsActive = false;
        // Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ChangeDisplay();
    }

    public void CreateLine(string text)
    {
        TextMeshProUGUI textMeshProUGUI = GameObject.Instantiate<TextMeshProUGUI>(textLine_Prototype, Vector3.zero, Quaternion.identity, content);
        textMeshProUGUI.text = text;
        lines.Add(textMeshProUGUI);
        textMeshProUGUI.gameObject.SetActive(true);
    }

    public void CreateLine(Node<Dialog> node)
    {
        string speaker = node.nodeEntity.speaker;
        string contents = node.nodeEntity.contents;
        if (speaker == ">>")
            CreateLine(Utility.Text.Format("<{0}>", contents));
        else
            CreateLine(Utility.Text.Format("{0}:{1}", speaker, contents));
    }

    public override void Show(UnityAction callback = null)
    {
        base.Show(callback);
        IsActive = true;
        if (animator.runtimeAnimatorController == null)
        {
            record.gameObject.SetActive(true);
            return;
        }
        animator.SetTrigger("FadeIn");
    }

    public override void Hide(UnityAction callback = null)
    {
        base.Hide(callback);
        IsActive = false;
        if (animator.runtimeAnimatorController == null)
        {
            record.gameObject.SetActive(false);
            return;
        }
        animator.SetTrigger("FadeOut");
    }

    public void ClearLines()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            Destroy(lines[i].gameObject);
        }
        lines.Clear();
    }

}