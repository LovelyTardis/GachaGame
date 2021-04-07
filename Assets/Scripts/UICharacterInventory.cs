using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterInventory : MonoBehaviour
{
    public static UICharacterInventory charInv;
    public GameObject characterStatsPanel;
    public GameObject characterInventoryPanel;
    public GameObject charactersUnlocked;
    public GameObject charactersLocked;
    
    
    public List<Character> allCharacters;
    public GameObject SlotPrefab;

    public List<UISlotCharacter> _allslots;
    public void Awake()
    {
        if (charInv == null)
            charInv = this;
        _allslots.Clear();
        foreach (Character ch in allCharacters)
        {
            GameObject slot = Instantiate(SlotPrefab) as GameObject;
            if (ch.unlocked)
            {
                slot.gameObject.transform.SetParent(charactersUnlocked.transform,false);
            }
            else
            {
                slot.gameObject.transform.SetParent(charactersLocked.transform,false);
            }
            UISlotCharacter slotChar = slot.GetComponent<UISlotCharacter>();
            slotChar.LoadSlot(ch,this);
            _allslots.Add(slotChar);
        }
    }

    public void LoadInventory()
    {

    }
    public void Sort()
    {
        foreach (UISlotCharacter slotChar in _allslots)
        {
            if (slotChar.character.unlocked)
            {
                 slotChar.gameObject.transform.SetParent(charactersUnlocked.transform,false);
            }
            else
            {
                 slotChar.gameObject.transform.SetParent(charactersLocked.transform,false);
            }
        }
    }

    public void CharacterPanel(Character ch)
    {
        characterStatsPanel.SetActive(true);
        UICharacterStats.charStats.LoadCharacter(ch);
        characterInventoryPanel.SetActive(false);
    }
}
