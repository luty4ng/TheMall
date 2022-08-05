using UnityEngine;
using System.Collections;
using GameKit;
public class Trigger : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null;
        EventManager.instance.EventTrigger("EventA");
        EventManager.instance.EventTrigger<string>("EventB", "EventB Data");
        EventManager.instance.EventTrigger<int, string>("EventC", 10, "EventC Data String");
    }
}