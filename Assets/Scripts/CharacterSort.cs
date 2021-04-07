using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSort : MonoBehaviour
{
    public UICharacterInventory characterInventory;
    private bool _filterBy5Stars;
    private bool _filterBy4Stars;
    private bool _filterBy3Stars;
    private bool _filterBy2Stars;
    private bool _filterBy1Stars;
    private Character.classSelector _lastSelector;
    private bool _showAll;

    private void Awake()
    {
        _showAll = true;
    }

    public void ShowAllClasses()
    {
        if(!_showAll)
            _showAll = true;
        int stars = CheckIfStarFilter();
        if (stars != 0)
        {
            foreach (UISlotCharacter slotCharacter in characterInventory._allslots)
            {
                if (slotCharacter.character.charStars.Equals(stars))
                {
                    slotCharacter.gameObject.SetActive(true);
                }
                else
                {
                    slotCharacter.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            foreach (UISlotCharacter slotCharacter in characterInventory._allslots)
            {
                slotCharacter.gameObject.SetActive(true);
            }
        }
    }
    public void ShowClassMage()
    {
        ClassSearcher(Character.classSelector.mage);
    }
    public void ShowClassHealer()
    {
        ClassSearcher(Character.classSelector.healer);
    }
    public void ShowClassMelee()
    {
        ClassSearcher(Character.classSelector.fighter);
    }
    public void ShowClassTank()
    {
        ClassSearcher(Character.classSelector.tank);
    }
    public void ClassSearcher(Character.classSelector characterClass)
    { 
        _showAll = false;
        _lastSelector = characterClass;
        int stars = CheckIfStarFilter();
        foreach (UISlotCharacter slotCharacter in characterInventory._allslots)
        {
            if (stars == 0)
                ActivateWithoutStarFilter(slotCharacter, characterClass);
            else
                ActivateWithStarFilter(slotCharacter, characterClass, stars);
        }
    }
    public void ActivateWithoutStarFilter(UISlotCharacter slotCharacter,Character.classSelector characterClass)
    {
        if (slotCharacter.character.charClass == characterClass)
        {
            slotCharacter.gameObject.SetActive(true);
        }
        else
        {
            slotCharacter.gameObject.SetActive(false);
        }
    }
    public void ActivateWithStarFilter(UISlotCharacter slotCharacter,Character.classSelector characterClass, int stars)
    {
        if (slotCharacter.character.charClass == characterClass && slotCharacter.character.charStars == stars)
        {
            slotCharacter.gameObject.SetActive(true);
        }
        else
        {
            slotCharacter.gameObject.SetActive(false);
        }
    }
    public int CheckIfStarFilter()
    {
        if (_filterBy1Stars) { return 1; }
        if (_filterBy2Stars) { return 2; }
        if (_filterBy3Stars) { return 3; }
        if (_filterBy4Stars) { return 4; }
        if (_filterBy5Stars) { return 5; }
        return 0;
    }
//omptimizar esta wea
    public void ShowByStars(int value)
    {
        _filterBy1Stars = false;
        _filterBy2Stars = false;
        _filterBy3Stars = false;
        _filterBy4Stars = false;
        _filterBy5Stars = false;
        switch (value)
        {
            case 1:
                _filterBy1Stars = true;
                break;
            case 2:
                _filterBy2Stars = true;
                break;
            case 3:
                _filterBy3Stars = true;
                break;
            case 4:
                _filterBy4Stars = true;
                break;
            case 5:
                _filterBy5Stars = true;
                break;
        }
        
        if (_showAll)
        {
            ShowAllClasses();
        }
        else
        {
            ClassSearcher(_lastSelector);
        }
    }
}
