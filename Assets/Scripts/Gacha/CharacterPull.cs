using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterPull : GachaSystem
{
 
    [Range(0f,100f)]
    public float rate3Star;
    [Range(0f,100f)]
    public float rate2Star;
    
    [Range(0f,1f)]
    public float rateBannerCharacters;
    
    public List<Character> bannerCharacters;
    public List<Character> noBannerCharacters;
    public GachaSlotManager slotManager;
    
    private List<Character> _pulledCharacters;
    
    /*******************TEMPORAL***********************/
    private List<Character> _list3Star;
    private List<Character> _list2Star;
    private List<Character> _list1Star;

    private List<Character> _listRateUp3Star;
    private List<Character> _listRateUp2Star;

    public void Awake()
    {
        _list1Star.Clear();
        _list2Star.Clear();
        _list3Star.Clear();
        _listRateUp3Star.Clear();
        _listRateUp2Star.Clear();
        foreach (Character ch in noBannerCharacters)
        {
            switch(ch.charStars)
            {
                case 1:
                    _list1Star.Add(ch);
                    break;
                case 2:
                    _list2Star.Add(ch);
                    break;
                case 3: 
                    _list3Star.Add(ch);
                    break;
            }
        }

        foreach (Character ch in bannerCharacters)
        {
            switch(ch.charStars)
            {
                case 2:
                    _listRateUp2Star.Add(ch);
                    break;
                case 3: 
                    _listRateUp3Star.Add(ch);
                    break;
            }
        }
    }
    /**************************************************/
    
    public override void Pull(int nOfPulls)
    {
        _pulledCharacters.Clear();
        
        for (int x = 0; x < nOfPulls; x++)
        {
            float pullRate = Random.Range(0f,100f);
            if (guaranteed3Star ||pullRate >= 0f && pullRate <= rate3Star)  //WHEN 3* IS PULLED
            {
                pullRate = Random.Range(0f,1f);
                if (pullRate <= rateBannerCharacters) { _pulledCharacters.Add(SelectRandomCharacter(_listRateUp3Star)); }
                else { _pulledCharacters.Add(SelectRandomCharacter(_list3Star)); }
                guaranteed3Star = false;
            }
            else if(guaranteed2Star || pullRate > 5f && pullRate <= rate2Star) //WHEN 2* IS PULLED
            {
                pullRate = Random.Range(0f,1f);
                if (pullRate <= rateBannerCharacters) { _pulledCharacters.Add(SelectRandomCharacter(_listRateUp2Star)); }
                else { _pulledCharacters.Add(SelectRandomCharacter(_list2Star)); }
                guaranteed2Star = false;
            }
            else // IF 2* AND 3* WHERE PULLED, 1* IS PULLED AS DEFAULT
            {
                _pulledCharacters.Add(SelectRandomCharacter(_list1Star));
            }
        }
        slotManager.LoadSlots(_pulledCharacters);
    }

    private Character SelectRandomCharacter(List<Character> listChar)
    {
        Character ch = listChar[Random.Range(0, listChar.Count)];
        return ch;
    }
}
