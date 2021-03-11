using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerDownHandler
{
    public TabGroup tabGroup;
    
    [Header("Button Image")]
    public Image background;
    
    [Header("Button Animations")] 
    public Color onBtnPressed;
    public Color onBtnSelected;
    public Color onBtnUnselected;
    
    private void Start() {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }
    

    public void OnPointerClick(PointerEventData eventData) {
        tabGroup.OnTabClicked(this);
    }
    public void OnPointerExit(PointerEventData eventData) {
        tabGroup.OnTabExit(this);
    }
    public void OnPointerDown(PointerEventData eventData){
        tabGroup.OnTabPressed(this);
    }
}
