using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    private static BattleController _instance;
    public CharactersParty charactersParty;
    public List<GameObject> PlayerCharSheet = new List<GameObject>();
    public List<GameObject> EnemyCharSheet = new List<GameObject>();
    private void Awake()
    {
        _instance = this;
        PartyToBattle();
    }
    private void Start()
    {
        BattlecrySkills();
        PlayerTurn();
    }
    void BattlecrySkills()
    {
        
    }
    void PlayerTurn()
    {
        //Activate Characters UI
        foreach (GameObject sheet in PlayerCharSheet) 
        {
            InteractableCharacter(sheet);
            for (int i = 0; i < 4; i++)
            {
                if (sheet.GetComponent<BattleSlot>().ch != null)
                {
                    var charSkill = sheet.GetComponent<BattleSlot>().ch;
                    if (charSkill.skills[i] != null)
                    {
                        if (charSkill.skills[i].type == SkillObject.Type.Passive)
                        {
                            charSkill.skills[i].SkillsFather.Effect();
                        }
                    }
                }
            }
        }
    }
    void EnemyTurn() { }
    public void InteractableCharacter(GameObject UICharacter)
    {
        if (UICharacter.GetComponent<BattleSlot>().ch != null)
        {
            var component = UICharacter.GetComponentsInChildren<Button>();
            foreach (Button button in component)
            {
                button.interactable = !button.interactable;
            }
        }
    }
    void PartyToBattle()
    {
        for (int i = 0; i < PlayerCharSheet.Count; i++)
        {
            if (PlayerCharSheet[i] != null)
            {
                PlayerCharSheet[i].GetComponent<BattleSlot>().ch = charactersParty.Characters[i];
            }
        }
    }
}
