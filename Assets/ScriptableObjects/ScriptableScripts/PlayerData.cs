using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Objects/New Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Info")]
    public string p_id;
    public string p_name;
    public int p_level;
    [Header("Player Stats")]
    public Int64 p_shards;
    public Int64 p_crystals;
    public int p_ap;
    public int p_exp;
    [Header("Max Stats")]
    public int p_maxAp;
    public int p_maxExp;
}
