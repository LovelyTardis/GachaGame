using UnityEngine;

public class Aqua : SkillsFather
{
    public override void Effect(InBattle character)
    {
        character.hp -= SkillData.SkillValue;
        base.Effect(character);
    }
}
