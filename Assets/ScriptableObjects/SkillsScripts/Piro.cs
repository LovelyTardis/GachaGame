using UnityEngine;

public class Piro : SkillsFather
{
    public override void Effect()
    {
        value = SkillData.SkillValue;
        string text = SkillData.Name + ", " + value;
        Debug.Log(text);
    }
}
