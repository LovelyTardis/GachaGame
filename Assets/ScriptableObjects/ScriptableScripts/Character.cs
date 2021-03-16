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
}
