using UnityEngine;

public abstract class SkillsFather : MonoBehaviour
{
    public SkillObject SkillData;

    public virtual void Effect(InBattle character)
    {
        Debug.Log("SelectedCharacter: " + character.name + "\n SkillName: " + name +", SkillValue: " + SkillData.SkillValue );
    }
}
