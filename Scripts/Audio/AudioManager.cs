using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private Sound[] musicSounds, sfxSounds;
    [SerializeField]
    private AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);
        if (sound == null)
            Debug.Log("Sound not found");
        else
        {
            musicSource.clip = sound.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);
        if (sound == null)
            Debug.Log("Sound not found");
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }

    public void PlaySFXLoop(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);
        if (sound == null)
            Debug.Log("Sound not found");
        else
        {
            sfxSource.clip = sound.clip;
            sfxSource.Play();
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
