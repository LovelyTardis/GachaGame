using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AssignSlider : MonoBehaviour
{
    public enum sliderEnum { exp, ap };
    public sliderEnum typeEnum;
    public PlayerData playerData;
    private Slider slider;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void Update()
    {
        switch(typeEnum)
        {
            case sliderEnum.ap:
                Current(playerData.p_ap, playerData.p_maxAp);
                break;
            case sliderEnum.exp:
                Current(playerData.p_exp, playerData.p_maxExp);
                break;
        }
    }

    public void Current(int current, int max)
    {
        slider.value = current;
        slider.maxValue = max;
    }
}
