using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class Budda : Item
{
    public Light2D light2D;
    public Light2D light2D2;
    protected override void OnStart()
    {
        base.OnStart();
        light2D = transform.parent.GetComponentInChildren<Light2D>();
        light2D2 = transform.parent.GetComponentInChildren<Light2D>();

    }
    public override void OnInteract()
    {
        base.OnInteract();
        light2D.intensity = 0;
        light2D2.intensity = 0;

    }

    public void LightUp()
    {
        light2D.intensity = 2.4f;
        light2D2.intensity = 2.4f;

    }


}