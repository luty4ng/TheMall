using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += ExitAfterPlayed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExitAfterPlayed(VideoPlayer vp)
    {
        this.gameObject.SetActive(false);
    }
}
