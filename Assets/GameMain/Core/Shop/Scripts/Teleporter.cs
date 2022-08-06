using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform Destination;
    [SerializeField] private Transform player;

    public void LoadNextLevel()
    {
        Debug.Log(Destination.position);
        player.position = Destination.position;
    }

}
