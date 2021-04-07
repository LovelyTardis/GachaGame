using UnityEngine;

public class Piro : SkillsFather
{
    public override void Effect(InBattle character)
    {
        string text = SkillData.Name + ", " + SkillData.SkillValue;
        Debug.Log(text);
    }
}
