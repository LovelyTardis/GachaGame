using UnityEngine;

public class Curar : SkillsFather
{
    public override void Effect()
    {
        value = SkillData.SkillValue;
        string text = SkillData.Name + ", " + value;
        Debug.Log(text);
    }
}
