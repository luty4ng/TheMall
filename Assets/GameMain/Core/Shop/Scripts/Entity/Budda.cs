using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class Budda : Item
{
    public Light2D light2D;
    protected override void OnStart()
    {
        base.OnStart();
        light2D = transform.parent.GetComponentInChildren<Light2D>();
    }
    public override void OnInteract()
    {
        base.OnInteract();
        light2D.intensity = 0;
    }

    public void LightUp()
    {
        light2D.intensity = 1;
    }


}