using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    private void Awake()
    {
        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.volume;
            sound.Source.pitch = sound.pitch;
            sound.Source.loop = sound.loop;
        }
    }

    private void Start()
    {
        Play("Background");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(Sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        sound.Source.Play();
    }
}
