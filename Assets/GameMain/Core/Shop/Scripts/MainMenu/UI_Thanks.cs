using UnityEngine;
using GameKit;
using UnityEngine.Events;

public class UI_Thanks : UIGroup
{
    public void ShowPanel()
    {
        Show();
    }

    public override void Show(UnityAction callback = null)
    {
        base.Show(callback);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
        {
            Hide();
        }
    }
}