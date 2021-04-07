using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICharacterStats : MonoBehaviour
{
    public static UICharacterStats charStats;
    public Image characterImage;
    public TextMeshProUGUI nameCharacter;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI atk;
    public TextMeshProUGUI mag;
    public TextMeshProUGUI defAtk;
    public TextMeshProUGUI defMag;
    public void Awake()
    {
        if (charStats == null)
            charStats = this;
    }

    public void LoadCharacter(Character ch)
    {
        // AssignCharacterText
        nameCharacter.text = ch.charName;
        hp.text = ch.hp.ToString();
        atk.text = ch.atk.ToString();
        mag.text = ch.mag.ToString();
        defAtk.text = ch.defAtk.ToString();
        defMag.text = ch.defMag.ToString();
        characterImage.sprite = ch.charImage;
    }
}
