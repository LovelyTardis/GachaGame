using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    TextMeshProUGUI textField;
    public string key;
    private void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        LoadLanguage();
    }
    public void LoadLanguage()
    {
        string value = LocalisationSystem.GetLocalisedValue(key);
        textField.text = value;
    }
}
