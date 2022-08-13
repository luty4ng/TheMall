using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    private Button btn;
    public bool isPressed;

    private void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        isPressed = false;
    }

    private void Update()
    {
        btn.onClick.AddListener(() => isPressed = true);
    }
}
