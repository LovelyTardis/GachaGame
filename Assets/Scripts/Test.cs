using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public float hp, atk, mag, defAtk, defMag, spd;
    public int stars;
    public Image cImage;
    public Character ch;
    private void Awake()
    {
        ch.InitializeStats(this);
    }
    public void ButtonEffect(int ability)
    {
        ch.ExecuteSkill(ability);
    }
}
