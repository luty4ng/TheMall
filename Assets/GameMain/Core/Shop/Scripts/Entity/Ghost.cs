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
    private Color ghostColor;
    private SpriteRenderer GhostSprite;
    public float transitionRate;

    private void Start()
    {
        GhostSprite = this.GetComponent<SpriteRenderer>();
        ghostColor = GhostSprite.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive)
            return;
        StartCoroutine(FadeEffect(transitionRate));
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

    IEnumerator FadeEffect(float transitionTime)
    {
        bool change = true;
        if (ghostColor.a > 0 && change)
        {
            ghostColor.a -= .01f;
            GhostSprite.color = ghostColor;
            yield return new WaitForSeconds(transitionTime * Time.deltaTime);
        }
        else change = false;
        if(ghostColor.a < 1 && !change)
        {
            ghostColor.a +=.01f;
            GhostSprite.color = ghostColor;
            yield return new WaitForSeconds(transitionTime * Time.deltaTime);
        }
        else change = true;
        Debug.Log(ghostColor.a);
    }
}
