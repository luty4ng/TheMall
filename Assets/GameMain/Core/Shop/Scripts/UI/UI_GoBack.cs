using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UI_GoBack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    private Sequence sequence;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Kill();
        sequence.Append(icon.DOFade(0, 0.3f));
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        sequence.Kill();
        sequence.Append(icon.DOFade(1, 0.3f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sequence.Kill();
        sequence.Append(icon.DOFade(0, 0.3f));
    }

}