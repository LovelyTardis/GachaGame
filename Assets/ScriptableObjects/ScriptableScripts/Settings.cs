using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // cambio idioma
    public enum LanguageSelect { Spanish, English };
    public LanguageSelect languageSelected;

    // cambiar volumen
    public float volume;

    private void Start()
    {
        if (languageSelected == LanguageSelect.English)
        {
            LocalisationSystem.SetLanguage(0);
        }
        else
        {
            LocalisationSystem.SetLanguage(1);
        }
        
    }
    public void LoadLanguage(TMPro.TMP_Dropdown dropdown)
    {
        LocalisationSystem.SetLanguage(dropdown.value);
    }
}
