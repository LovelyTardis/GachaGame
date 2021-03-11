using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIStarControler : MonoBehaviour
{
    public Image border;
    public List<Image> stars;
    public Sprite ActiveStar;
    public Sprite UnactiveStar;

    public Sprite goldBorder;
    public Sprite silverBorder;
    public Sprite bronzeBorder;
    public Test CharacterLvl;
    private int _lvl;

    private void Start()
    {
        UpdateStars();
        UpdateBorder();
    }

    void Update()
    {
        if (_lvl == CharacterLvl.stars)
        {
            return;
        }

        UpdateStars();
        UpdateBorder();
    }

    public void UpdateStars()
    {
        _lvl = CharacterLvl.stars;
        for (int i = 0; i < stars.Count; i++)
        {
            if(i < CharacterLvl.stars)
                stars[i].sprite = ActiveStar;
            else
                stars[i].sprite = UnactiveStar;
        }
    }
    public void UpdateBorder()
    {
        switch(_lvl)
        {
            case 1:
            case 2:
                border.sprite = bronzeBorder;
                break;
            case 3:
            case 4:
                border.sprite = silverBorder;
                break;
            case 5:
                border.sprite = goldBorder;
                break;
            default:
                break;
        }
    }

  
}
