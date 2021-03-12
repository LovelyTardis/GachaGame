using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/New Character")]
public class Character : ScriptableObject
{
    public enum classSelector { melee, mage, tank, healer};
    [Header("Character Info")]
    public string charName;
    public Sprite charImage;
    public int charStars;
    public classSelector charClass;
    [Header("Character Unlocked")]
    public bool unlocked;
    [Header("Character Stats")]
    public float hp;
    public float atk;
    public float mag;
    public float defAtk;
    public float defMag;
    public float spd;
    [Header("Character Skills")]
    public SkillObject[] skills = new SkillObject[4];
    public void InitializeStats(Test test)
    {
        test.stars = charStars;
        test.hp = hp;
        test.atk = atk;
        test.mag = mag;
        test.defAtk = defAtk;
        test.defMag = defMag;
        test.spd = spd;
        test.cImage.sprite = charImage;
    }
    public void ExecuteSkill(int id)
    {
        switch (id)
        {
            case 1: skills[0].SkillsFather.Effect(); break;
            case 2: skills[1].SkillsFather.Effect(); break;
            case 3: skills[2].SkillsFather.Effect(); break;
            case 4: skills[3].SkillsFather.Effect(); break;
        }
    }
}
