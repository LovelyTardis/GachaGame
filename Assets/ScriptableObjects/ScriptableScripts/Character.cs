using System.Collections;
using System.Collections.Generic;
using Battle;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/New Character")]
public class Character : ScriptableObject
{
    public enum classSelector { fighter, mage, tank, healer};
    [Header("Character Info")]
    public string charName;
    public Sprite charImage;
    public Sprite charSprite;
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
    
    public void LoadStatsCharacter(InBattle inBattle)
    {
        inBattle.hp = hp;
        inBattle.atk = atk;
        inBattle.mag = mag;
        inBattle.defAtk = defAtk;
        inBattle.defMag = defMag;
        inBattle.spd = spd;
    }
    public void LoadUICharacter(BattleSlot battleSlot)
    {
        battleSlot.cImage.sprite = charImage;
    }
    
}
