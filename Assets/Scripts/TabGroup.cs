////////////////////////////////////////////
//* ALL TERMS OF COPYRIGHT ASK TO GUNTER_*//
////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public TabButton selectedBtn;
    public List<GameObject> objectsToSwap;
    [Range(0, 1)] public float time;

    public void Start()
    {
        if(selectedBtn != null)
            OnTabClicked(selectedBtn);
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabClicked(TabButton button)
    {
        button.background.color = button.onBtnSelected;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++) {
            if (i == index) 
                 StartCoroutine(Active(objectsToSwap[i], objectsToSwap[i].GetComponent<CanvasGroup>()));
            else 
                 StartCoroutine(Deactive(objectsToSwap[i], objectsToSwap[i].GetComponent<CanvasGroup>()));
        }
    }
    public void OnTabPressed(TabButton button) {
        selectedBtn = button;
        button.background.color = button.onBtnPressed;
        ResetTabs();
    }
    public void OnTabExit(TabButton button) {
        ResetTabs();
    }

    public void ResetTabs() {
        foreach (TabButton button in tabButtons) {
            if(selectedBtn != null && button == selectedBtn) { continue; }
            button.background.color = button.onBtnUnselected;
        }
    }

    IEnumerator Active(GameObject Panel, CanvasGroup uiElement) {
        Panel.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, time));
    }
    IEnumerator Deactive(GameObject Panel, CanvasGroup uiElement) {
        yield return StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, time));
        Panel.SetActive(false);
    }

    
    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1) {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true) {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }
    }
}
