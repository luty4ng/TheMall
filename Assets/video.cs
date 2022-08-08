using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class video : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip videoContent;
    [SerializeField] GameObject Screen;
    [SerializeField] UnityEvent AfterVideo;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += ExitAfterPlayed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prepareVideo()
    {
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.clip = videoContent;
        Screen.SetActive(true);
    }
    void ExitAfterPlayed(VideoPlayer vp)
    {
        Screen.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(false);
        AfterVideo?.Invoke();
    }
}
