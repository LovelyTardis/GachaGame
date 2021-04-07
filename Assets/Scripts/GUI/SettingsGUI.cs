using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsGUI : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;
    public Slider musicSlider;
    public Slider effectsSlider;
    private void OnEnable()
    {
        languageDropdown.value = SettingsManager.Instance.LanguageValue;
        musicSlider.value = SettingsManager.Instance.MusicVolume;
        effectsSlider.value = SettingsManager.Instance.SoundEffectsVolume;
    }
}