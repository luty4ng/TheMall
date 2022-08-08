using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_animation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void PlayExit()
    {
        print("nihao");
        animator.Play("走路");
    }
}
