using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/New Skill")]
public class SkillObject : ScriptableObject
{
    public string Name;
    public string Description;
    public int Cost;
    public float SkillValue;
    public SkillsFather SkillsFather;
    public enum Type{Active, Passive, Battlecry};
    public Type type;
}
