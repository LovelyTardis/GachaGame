using UnityEngine;

public class Terratemblor : SkillsFather
{
    public override void Effect(InBattle character)
    {
        string text = SkillData.Name + ", " + SkillData.SkillValue;
        Debug.Log(text);
    }
}
