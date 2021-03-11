using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    private static BattleController Instance;
    public List<GameObject> CharSheet = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
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
        foreach (GameObject sheet in CharSheet) 
        {
            InteractableCharacter(sheet);
            for (int i = 0; i < 4; i++)
            {
                var charSkill = sheet.GetComponent<Test>().ch;
                if (charSkill.skills[i].type == SkillObject.Type.Passive)
                {
                    charSkill.skills[i].SkillsFather.Effect();
                }
            }
        }
    }
    void EnemyTurn() { }
    public void InteractableCharacter(GameObject UICharacter)
    {
        var component = UICharacter.GetComponentsInChildren<Button>();
        foreach (Button button in component)
        {
            button.interactable = !button.interactable;
        }
    }
}
