using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelLightOff : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D[] light2Ds;
    public float showSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        light2Ds = GetComponentsInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
 
    public void HideAllLight()
    {
        foreach (var light2D in light2Ds)
        {
            StartCoroutine(SlowlyHideLight(light2D));
        }
    }
    
    IEnumerator SlowlyHideLight(UnityEngine.Rendering.Universal.Light2D light2D)
    {
        while (light2D.intensity > 0.3f)
        {
            yield return null;
            light2D.intensity -= showSpeed * Time.deltaTime;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log($"Hide Lights");
            HideAllLight();
        }
    }
}
