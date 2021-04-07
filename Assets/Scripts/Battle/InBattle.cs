using Battle;
using UnityEngine;

public class InBattle : MonoBehaviour
{
    public CharactersParty party;
    public float hp, atk, mag, defAtk, defMag, spd;
    public int slot = 0;
    private void Start()
    {
        if(party.characters[slot] != null)
            party.characters[slot].LoadStatsCharacter(this);
    }
    public void SelectedTarget()
    {
        //BattleManager.Instance.buttonComponents = null; PARA BOTON RETREAT
        var loadFile = Resources.Load(BattleSlot.path) as Character;
        loadFile.skills[BattleSlot.lastSkillUsed].SkillsFather.Effect(this);
    }
}
