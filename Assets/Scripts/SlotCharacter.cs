using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCharacter : MonoBehaviour
{
    public Image slotImage;
    public Image slotBorder;
    public Character character;
    public BorderController bc;
    private bool _oldlocketvalue;
    public void Awake()
    {
        if (character != null)
        { 
            LoadSlot(character);
            SetSlotColor();
        }

    }
    public void LoadForGachaSlot(Character ch)
    {
        character = ch;
        slotImage.sprite = ch.charImage;
        slotBorder.sprite = bc.SetGoldBorder();
    }
    public void LoadSlot(Character ch)
    {
        character = ch;
        slotImage.sprite = ch.charImage;
        slotBorder.sprite = bc.SetBorder(ch);
        SetSlotColor();
    }
    
    //ESTO HAY QUE CAMBIARLO YA QUE SOLO PASARA DE LOCKED A UNLOCKED UNA VEZ, NO TIENE PORQUE ESTAR MIRANDOLO TODO EL RATO.
    public void Update()
    {
        if(_oldlocketvalue == character.unlocked){return;}
        SetSlotColor();
        UICharacterInventory.charInv.Sort();
    }

    public void SetSlotColor()
    {
        _oldlocketvalue = character.unlocked;
        if (!character.unlocked)
        {
            slotImage.color = Color.grey;
        }
        else
        {
            slotImage.color = Color.white;
        }
    }
}
