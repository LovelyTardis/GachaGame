using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : SingletonSystem
{
    /////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Singleton of AudioManager
    /// </summary>
    public static AudioManager Instance { get; private set; }
    protected override void BuildSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    
    public Sound[] sounds;
    void Awake()
    {
        BuildSingleton();
        foreach (Sound sound in sounds)
        {
            LoadSound(sound);
        }
    }
    //If the sound is a music, the volume will be changed to match with the SettingsManager.MusicVolume value
    //This works with all typeSound.Music in sounds
    public void ChangeMusicVolume()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.typeSound.Equals(Sound.TypeSound.Music))
            {
                sound.source.volume = SettingsManager.Instance.MusicVolume;
            }
        }
    }
    //If the sound is an effect, the volume will be changed to match with the SettingsManager.SoundEffectsVolume value
    //This works with all typeSound.Effect in sounds
    public void ChangeEffectsVolume()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.typeSound.Equals(Sound.TypeSound.Effect))
            {
                sound.source.volume = SettingsManager.Instance.SoundEffectsVolume;
            }
        }
    }
    //Create the AudioSource of the selected sound and applies the volume
    public void LoadSound(Sound sound)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        //Selects the typeSound and sets the volume
        switch (sound.typeSound)
        {
            case Sound.TypeSound.Music:
                sound.source.volume = SettingsManager.Instance.MusicVolume;
                break;
            case Sound.TypeSound.Effect:
                sound.source.volume = SettingsManager.Instance.SoundEffectsVolume;
                break;
            default:
                break;
        }
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
    }
    //Play the sound by the name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    //Stop the sound by the name
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
