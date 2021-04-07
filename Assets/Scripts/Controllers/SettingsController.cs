using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using Debug = UnityEngine.Debug;

public class SettingsController : MonoBehaviour
{
    public void OnMusicVolumeChanged(Slider volume)
    {
        SettingsManager.Instance.MusicVolume = volume.value;
        AudioManager.Instance.ChangeMusicVolume();
    }
    public void OnEffectsVolumeChanged(Slider volume)
    {
        SettingsManager.Instance.SoundEffectsVolume = volume.value;
        AudioManager.Instance.ChangeEffectsVolume();
    }
    public void OnLanguageChanged(TMP_Dropdown language)
    {
        bool correctValue = true;
        switch (language.value)
        {
            case 0:
            case 1:
                break;
            default:
                correctValue = false;
                break;
        }
        if (correctValue)
        {
            SettingsManager.Instance.LanguageValue = language.value;
        }
    }
    public void SaveSettings()
    {
        SettingsManager.Instance.Save();
    }
    private void OnDisable()
    {
        SaveSettings();
    }
}
