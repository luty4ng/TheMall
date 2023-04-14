using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AuntTrigger : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2Ds;
    public float showSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        light2Ds.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerAgent player = col.gameObject.GetComponent<PlayerAgent>();
            
            if (player.currentWorld == "WorldB")
                ShowAllLight();
        }
    }
    
    public void ShowAllLight()
    {
        StartCoroutine(SlowlyShowLight(light2Ds));
    }

    IEnumerator SlowlyShowLight(UnityEngine.Rendering.Universal.Light2D light2D)
    {
        while (light2D.intensity < 1)
        {
            yield return null;
            light2D.intensity += showSpeed * Time.deltaTime;
        }
    }
}
