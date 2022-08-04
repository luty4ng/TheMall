using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform Goal;
    public float speed;
    private float distance;
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        distance = Goal.position.x - transform.position.x;
        if (Mathf.Abs(distance) > 0)
        {
            movement = new Vector3(Mathf.Sign(distance) * Time.deltaTime * speed, 0, 0);
            transform.Translate(movement);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        { Debug.Log("Gotcha"); }
    }

    
}
