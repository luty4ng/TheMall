using UnityEngine;
using GameKit;
using System.Collections.Generic;
public class GlobalSound : MonoSingletonBase<GlobalSound>
{
    public AudioSource audioSource;

    public List<AudioClip> musics = new List<AudioClip>();
    public List<AudioClip> sounds = new List<AudioClip>();
    private Dictionary<string, AudioClip> m_cachedSounds = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> m_cachedMusics = new Dictionary<string, AudioClip>();
    protected override void OnAwake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        for (int i = 0; i < musics.Count; i++)
        {
            m_cachedMusics.Add(musics[i].name, musics[i]);
        }

        for (int i = 0; i < sounds.Count; i++)
        {
            m_cachedSounds.Add(sounds[i].name, sounds[i]);
        }
    }

    public void PlaySound(string name, float volume, bool isLoop = false)
    {
        if (m_cachedSounds.ContainsKey(name) && !audioSource.isPlaying)
        {
            // Debug.Log($"Play shit");
            audioSource.clip = m_cachedSounds[name];
            audioSource.volume = volume;
            audioSource.Play();
        }
        else
        {
            audioSource.volume = volume;
            Utility.Debugger.LogFail(volume.ToString());
        }
    }

}