using UnityEngine;
using DG.Tweening;
public class FemaleStatus : Item
{
    public void MoveToRight()
    {
        Debug.Log($"MoveToRight");
        this.transform.DOMoveX(this.transform.position.x - 3, 0.2f);
    }
}