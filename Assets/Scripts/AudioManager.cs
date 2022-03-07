using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in Sounds)
        {
            GameObject newSoundObject = new GameObject(sound.name);
            newSoundObject.transform.SetParent(transform);

            sound.Source = newSoundObject.AddComponent<AudioSource>();
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

    public void Stop(string name)
    {
        Sound sound = Array.Find(Sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }

        sound.Source.Stop();
    }
}