using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExp : MonoBehaviour
{
    public void SubirExp(int exp)
    {
        PlayerLvlSystem.Ls.playerData.p_exp += exp;
        PlayerLvlSystem.Ls.CheckLevelUp();
    }
}
