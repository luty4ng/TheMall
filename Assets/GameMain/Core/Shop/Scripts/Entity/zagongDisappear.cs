using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zagongDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < -28)
        {
            Disactive();
        }
    }

    public void Disactive()
    {
        this.gameObject.SetActive(false);
    }
}
