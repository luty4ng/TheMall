using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

public class PlayerAgent : MonoBehaviour
{
    public const string PASSENTER_EVENT = "Player Pass Enter";
    public const string PASSEXIT_EVENT = "Player Pass Exit";
    public float speed = 10;
    private float horizontal;
    private Vector3 movement;
    private DialogSystem dialogSystem;
    private IInteractive currentEntity;
    private UI_Bubble uI_Bubble;
    private void Start()
    {
        dialogSystem = GameKitComponentCenter.GetComponent<DialogSystem>();
        uI_Bubble = UIManager.instance.GetUI<UI_Bubble>("UI_Bubble");
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(horizontal * Time.deltaTime * speed, 0, 0);
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentEntity != null)
            {
                currentEntity?.OnInteract();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Enter");
        if (other.tag == "Collective" || other.tag == "Exit")
        {
            currentEntity = other.GetComponent<IInteractive>();
            currentEntity.OnPassEnter();
            uI_Bubble.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Exit");
        if (other.tag == "Collective" || other.tag == "Exit")
        {
            if (currentEntity == null)
                currentEntity = other.GetComponent<IInteractive>();
            currentEntity?.OnPassExit();
            uI_Bubble.Hide();
        }
    }
}
