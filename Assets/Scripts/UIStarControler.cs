using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIStarControler : MonoBehaviour
{
    public List<Image> stars;
    public Sprite ActiveStar;
    public Sprite UnactiveStar;
    
    public SlotCharacter CharacterLvl;
    private int _lvl;

    private void Start()
    {
        UpdateStars();
    }

    void Update()
    {
        if (_lvl == CharacterLvl.character.charStars)
        {
            return;
        }

        UpdateStars();
    }

    public void UpdateStars()
    {
        _lvl = CharacterLvl.character.charStars;
        for (int i = 0; i < stars.Count; i++)
        {
            if(i < CharacterLvl.character.charStars)
                stars[i].sprite = ActiveStar;
            else
                stars[i].sprite = UnactiveStar;
        }
    }
    

  
}
