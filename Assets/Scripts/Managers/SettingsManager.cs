using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SettingsManager : SingletonSystem
{
    /////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Singleton of SettingsManager
    /// </summary>
    public static SettingsManager Instance { get; private set; }    
    protected override void BuildSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    #region Public Variables
    public float MusicVolume
    {
        get => musicVolume;
        set => musicVolume = value;
    }
    public float SoundEffectsVolume
    {
        get => soundEffectsVolume;
        set => soundEffectsVolume = value;
    }
    public int LanguageValue
    {
        get => languageValue;
        set => languageValue = value;
    }
    #endregion
    
    #region Private Variables
    [Range(0, 1f)]
    [SerializeField] private float musicVolume;
    [Range(0, 1f)]
    [SerializeField] private float soundEffectsVolume;
    [Tooltip("0 = English | 1 = Spanish")]
    [SerializeField] private int languageValue;
    #endregion
    private void Awake()
    {
        BuildSingleton();
        Load();
    }

    public void Load()
    {
        //load the data
        GameSettings gameSettings = DataManagerUtils.LoadFile<GameSettings>( "/GameSettings.dat");
        //look if the data not null
        if (gameSettings != null) {
            musicVolume = gameSettings.musicVolume;
            soundEffectsVolume = gameSettings.soundEffectsVolume;
            languageValue = gameSettings.language;
        }

    }

    public void Save()
    {
        //we create the data
        GameSettings gameSettings = new GameSettings();
        gameSettings.musicVolume = musicVolume;
        gameSettings.soundEffectsVolume = soundEffectsVolume;
        gameSettings.language = languageValue;
        //save the data
        DataManagerUtils.SaveFile(gameSettings, "/GameSettings.dat");
    }
}

