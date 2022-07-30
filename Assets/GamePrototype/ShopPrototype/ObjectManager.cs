using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameKit;

public class ObjectManager : MonoBehaviour
{
    private DialogSystem dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collective")
        {
           var temp = other.GetComponent<Item>();
            if (temp.Collectable)
            { 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    temp.Window?.SetActive(true);
                    Exit.NumItem++;
                    Destroy(other.gameObject);
                }
            }
        }
        if (other.tag == "Exit") 
        {
            var temp = other.GetComponent<Exit>();
            dialogSystem.StartDialog(temp.Dialog.title, temp.Dialog.contents);
        }
    }
}
