using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAppear : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;
    private float character_a;
    void Start()
    {
        color = this.GetComponent<SpriteRenderer>().color;
         character_a = this.GetComponent<SpriteRenderer>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        while(character_a < 1)
        {
            character_a += Time.deltaTime * .1f;
            color.a = character_a;
            this.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
