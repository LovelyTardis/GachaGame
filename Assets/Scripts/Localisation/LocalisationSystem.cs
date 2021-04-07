using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem
{
    public enum Language
    {
        English,
        Spanish
    }

    public static Language language;
    public static void SetLanguage(int value)
    {
        bool allOk = true;
        switch (value)
        {
            case 0:
                language = Language.English;
                break;
            case 1:
                language = Language.Spanish;
                break;
            default:
                allOk = false;
                break;
        }
        if (allOk) { SettingsManager.Instance.LanguageValue = value; }
    }

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedES;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader.csv.LoadCSV();

        localisedEN = CSVLoader.csv.GetDictionaryValues("en");
        localisedES = CSVLoader.csv.GetDictionaryValues("es");

        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if (!isInit) { Init(); }

        string value = key;

        switch(SettingsManager.Instance.LanguageValue)
        {
            case 0:
                localisedEN.TryGetValue(key, out value);
                break;
            case 1:
                localisedES.TryGetValue(key, out value);
                break;
        }
        return value;
    }
}
