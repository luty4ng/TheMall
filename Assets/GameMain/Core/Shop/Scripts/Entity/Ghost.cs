using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ghost : MonoBehaviour
{
    public Transform Goal;
    public float speed;
    private float distance;
    private Vector3 movement;
    private bool isActive = false;
    public UnityEvent onCaught;
    public Animator anim;
    public bool facingRight = true;
    public bool isFading = false;
    public bool canDestroy = true;

    // Update is called once per frame
    void Update()
    {

        if (!isActive)
            return;
        distance = Mathf.Abs(Goal.position.x - transform.position.x);
        if (distance > 0.3)
        {
            movement = new Vector3(Mathf.Sign(Goal.position.x - transform.position.x) * Time.deltaTime * speed, 0, 0);
            transform.Translate(movement);
            if(anim != null)
            {
                anim.SetFloat("Speed", Mathf.Abs(speed));
                if (movement.x > 0 && !facingRight) flip();
                if (movement.x < 0 && facingRight) flip();
            }
        }else
        {
            if (anim != null) anim.SetFloat("Speed", 0);
            // if (canDestroy) Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gotcha");
            onCaught?.Invoke();
        }
    }

    public void SetActive()
    {
        isActive = true;
        this.gameObject.SetActive(true);
    }

    void flip()
    {
        Vector3 currentScale = this.gameObject.transform.localScale;
        currentScale.x *= -1;
        this.gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
