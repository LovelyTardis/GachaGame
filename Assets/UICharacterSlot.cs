using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSlot : MonoBehaviour
{
    public bool locked;
    public Image charImage;
    private bool _oldlocketvalue;
    public void Awake()
    {
        SetSlotColor();
    }

    public void Update()
    {
        if(_oldlocketvalue == locked){return;}
        SetSlotColor();
    }

    public void SetSlotColor()
    {
        _oldlocketvalue = locked;
        if (locked)
        {
            charImage.color = Color.grey;
        }
        else
        {
            charImage.color = Color.white;
        }
    }
}
