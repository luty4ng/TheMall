using UnityEngine;
using GameKit;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;
public class RedLights : MonoSingletonBase<RedLights>
{
    public Light2D[] light2Ds;
    public float showSpeed = 1;
    public Light2D globalLight;
    private void Start()
    {
        light2Ds = GetComponentsInChildren<Light2D>();
        foreach (var light2D in light2Ds)
        {
            light2D.intensity = 0;
        }

    }

    public void ShowAllLight()
    {
        StartCoroutine(SlowlyHideLight(globalLight));
        foreach (var light2D in light2Ds)
        {
            StartCoroutine(SlowlyShowLight(light2D));
        }
    }

    IEnumerator SlowlyShowLight(Light2D light2D)
    {
        while (light2D.intensity < 1)
        {
            yield return null;
            light2D.intensity += showSpeed * Time.deltaTime;
        }
    }

    IEnumerator SlowlyHideLight(Light2D light2D)
    {
        while (light2D.intensity > 0.3f)
        {
            yield return null;
            light2D.intensity -= showSpeed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log($"Show Lights");
            ShowAllLight();
        }
    }

}