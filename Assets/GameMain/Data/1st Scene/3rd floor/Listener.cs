using UnityEngine;
using GameKit;
public class Listener : MonoBehaviour
{
    private void Start()
    {
        EventManager.instance.AddEventListener("EventA", () =>
        {
            Debug.Log($"EventA Recieved.");
        });

        EventManager.instance.AddEventListener<string>("EventB", (string data) =>
        {
            Debug.Log($"EventB Recieved. Data: " + data);
        });

        EventManager.instance.AddEventListener<int, string>("EventB", ProcessEventC);
    }

    private void ProcessEventC(int number, string data)
    {
        Debug.Log($"EventC Recieved. Number: " + number + "Data: " + data);
    }
}