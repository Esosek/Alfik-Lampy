using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public class Sound : ScriptableObject
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(-3f, 3f)]
    public float pitch;

    public bool loop;
    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource source;
}
