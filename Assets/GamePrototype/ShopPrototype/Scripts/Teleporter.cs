using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform Destination;
    [SerializeField] private Transform player;

    public void Teleport()
    {
        player.position = Destination.position;
    }
}
