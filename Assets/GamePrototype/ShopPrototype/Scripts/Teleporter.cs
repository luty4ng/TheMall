using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform Destination;
    [SerializeField] private Transform player;
    [SerializeField] private float transitionTime = .1f;
    [SerializeField] private Animator anim;

    public void Teleport()
    {
        player.position = Destination.position;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        Teleport();
        anim.ResetTrigger("Start");
        anim.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        anim.ResetTrigger("End");
    }
}
