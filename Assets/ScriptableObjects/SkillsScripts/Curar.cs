using UnityEngine;

public class Curar : SkillsFather
{
    public override void Effect(InBattle character)
    {
        character.hp += SkillData.SkillValue;
        base.Effect(character);
    }
}
