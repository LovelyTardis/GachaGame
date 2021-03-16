using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSlot : MonoBehaviour
{
    public float hp, atk, mag, defAtk, defMag, spd;
    public int stars;
    public Image cImage;
    public Character ch;
    private void Start()
    {
        if (ch != null)
            InitializeStats();
    }
    private void InitializeStats()
    {
        stars = ch.charStars;
        hp = ch.hp;
        atk = ch.atk;
        mag = ch.mag;
        defAtk = ch.defAtk;
        defMag = ch.defMag;
        spd = ch.spd;
        cImage.sprite = ch.charImage;
    }
    public void ButtonEffect(int ability)
    {
        switch (ability)
        {
            case 1: ch.skills[0].SkillsFather.Effect(); break;
            case 2: ch.skills[1].SkillsFather.Effect(); break;
            case 3: ch.skills[2].SkillsFather.Effect(); break;
            case 4: ch.skills[3].SkillsFather.Effect(); break;
        }
    }
}
