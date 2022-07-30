using UnityEngine;
using UnityEngine.UI;
using GameKit;
using TMPro;
public class UI_CloseUp : UIGroup
{
    public Image closeUpImage;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    protected override void OnStart()
    {
        base.OnStart();
        panelCanvasGroup.alpha = 0f;
    }

    public void SetCloseUp(Sprite sprite, string name, string desc)
    {
        closeUpImage.sprite = sprite;
        Name.text = name;
        Description.text = desc;
    }
}