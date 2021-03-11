using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLvlSystem : MonoBehaviour
{
    public static PlayerLvlSystem Ls;
    public PlayerData playerData;
    public GameObject levelUpPanel;
    public TMP_Text panelTextLvl;
    public TMP_Text panelTextAp;

    private void Awake()
    {
        if (Ls == null)
            Ls = gameObject.GetComponent<PlayerLvlSystem>();
    }

    public void CheckLevelUp()
    {
        int lvl = playerData.p_level;
        int ap = playerData.p_maxAp;
        while(playerData.p_exp >= playerData.p_maxExp)
        {
            playerData.p_exp -= playerData.p_maxExp;
            playerData.p_level++;
            playerData.p_maxAp++;
            playerData.p_ap += playerData.p_maxAp;
            playerData.p_maxExp = 25 * playerData.p_level * (1 + playerData.p_level);
            if (playerData.p_exp < playerData.p_maxExp)
            {
                panelTextLvl.text = lvl.ToString();
                panelTextAp.text = ap.ToString();
                levelUpPanel.SetActive(true);
            }
        }
    }
}
