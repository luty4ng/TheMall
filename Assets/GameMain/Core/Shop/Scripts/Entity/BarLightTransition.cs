using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLightTransition : MonoBehaviour
{
    public Animator animator;

    public GameObject betweening;

    private float wucha = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((betweening.transform.position.x  <= this.transform.position.x + wucha) && (betweening.transform.position.x  >= this.transform.position.x - wucha))
        {
            animator.SetBool("Right_Position", true);
        }
        else
        {
            animator.SetBool("Right_Position", false);
        }
    }
}
