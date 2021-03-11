using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : SkillsFather
{
    public override void Effect()
    {
        value = SkillData.SkillValue;
        string text = SkillData.Name + ", " + value;
        Debug.Log(text);
    }
}
