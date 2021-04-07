using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : SkillsFather
{
    public override void Effect(InBattle character)
    {
        string text = SkillData.Name + ", " + SkillData.SkillValue;
        Debug.Log(text);

    }
}
