using UnityEngine;
using GameKit;
using System.Collections;
using System.Collections.Generic;
public class GlobalSound : MonoSingletonBase<GlobalSound>
{
    private AudioSource audioSource;
    public AudioSource bgm1;
    public AudioSource bgm2;
    public AudioSource stepSound, flipping;
    [Header("声音渐变的速度"), Range(0f, 1f)] public float GradientSpeed = 0.2f;
    public List<AudioClip> musics = new List<AudioClip>();
    public List<AudioClip> sounds = new List<AudioClip>();
    private Dictionary<string, AudioClip> m_cachedSounds = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> m_cachedMusics = new Dictionary<string, AudioClip>();
    protected override void OnAwake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
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
            audioSource.loop = isLoop;
            audioSource.Play();
        }
        else
        {
            audioSource.volume = volume;
            // Utility.Debugger.LogFail(volume.ToString());
        }
    }

    public void PlayMusic(string name, float volume, bool isLoop = false)
    {
        if (m_cachedMusics.ContainsKey(name) && !audioSource.isPlaying)
        {
            // Debug.Log($"Play shit");
            audioSource.clip = m_cachedMusics[name];
            audioSource.volume = volume;
            audioSource.loop = isLoop;
            audioSource.Play();
        }
        else
        {
            audioSource.volume = volume;
            Utility.Debugger.LogFail(volume.ToString());
        }
    }

    public void StopSound(string name)
    {
        if (m_cachedSounds.ContainsKey(name) && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            Utility.Debugger.LogFail("Can not stop sound {0}.", name);
        }
    }

    public void StopMusic(string name)
    {
        if (m_cachedMusics.ContainsKey(name) && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            Utility.Debugger.LogFail("Can not stop music {0}.", name);
        }
    }
    public void PlayCustomMusic(AudioClip clip, float volume, bool isLoop = false)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = isLoop;
        audioSource.Play();
    }

    public void PlayCustomSound(AudioClip clip, float volume, bool isLoop = false)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = isLoop;
        audioSource.Play();
    }
    public void PlayCustomMusicGradually(AudioClip clip, bool isLoop = false)
    {
        if (clip == null)
        {
            Utility.Debugger.LogError("World AudioClip is Null, Set it in World Component.");
            return;
        }
        Debug.Log(bgm1.isPlaying + " >> " + bgm2.isPlaying);
        if ((bgm1.isPlaying && !bgm2.isPlaying) || (!bgm1.isPlaying && !bgm2.isPlaying))
        {
            Debug.Log($"Mode 1");
            bgm2.clip = clip;
            bgm2.volume = 0;
            bgm2.Play();
            StartCoroutine(ReduceVolume(bgm1));
            StartCoroutine(IncreaseVolume(bgm2));
        }
        else if (bgm2.isPlaying && !bgm1.isPlaying)
        {
            Debug.Log($"Mode 2");
            bgm1.clip = clip;
            bgm1.volume = 0;
            bgm1.Play();
            StartCoroutine(ReduceVolume(bgm2));
            StartCoroutine(IncreaseVolume(bgm1));
        }
    }

    IEnumerator ReduceVolume(AudioSource source)
    {
        while (source.volume > 0)
        {
            yield return null;
            source.volume -= Time.deltaTime * GradientSpeed;
        }
        source.Stop();
    }

    IEnumerator IncreaseVolume(AudioSource source)
    {
        while (source.volume < 1)
        {
            yield return null;
            source.volume += Time.deltaTime * GradientSpeed;
        }
    }
}