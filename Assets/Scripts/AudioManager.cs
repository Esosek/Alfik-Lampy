using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    [HideInInspector] public float musicVolume;
    [HideInInspector] public float soundVolume;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }

        else
            instance = this;


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }

    public void Play(Sound sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound.name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound.name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void Stop(Sound sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound.name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound.name + " not found!");
            return;
        }


        s.source.Stop();
    }
}
