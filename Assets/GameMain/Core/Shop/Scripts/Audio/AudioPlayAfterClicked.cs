using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayAfterClicked : MonoBehaviour
{
    public AudioSource voicePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio()
    {
        voicePlayer.Play();
    }
}
