using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject Window;
    public bool Collectable;
    public DialogAsset Dialog;
    public string ItemDescription;
    public string ItemName;
    private Image Itemimage;
    private Text Name;
    private Text Description;
    private void Awake()
    {
        Itemimage = Window.transform.GetChild(0).gameObject.GetComponent<Image>();
        Description = Window.transform.GetChild(1).gameObject.GetComponent<Text>();
        Name = Window.transform.GetChild(2).gameObject.GetComponent<Text>();
        Collectable = false;
    }

    void Update()
    {
        if (Collectable)
        {
            Itemimage.sprite = this.gameObject.GetComponent<Image>().sprite;
            Name.text = ItemName;
            Description.text = ItemDescription;
        }
    }
}
