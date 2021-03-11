using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class AssignPlayerText : MonoBehaviour
{
    public PlayerData playerData;
    public enum textChose { id, name, level, ap, exp, shards, crystals, maxAp, maxExp, numLevel };
    public textChose text;
    private TMP_Text tmpText;
    private void Start()
    {
        tmpText = gameObject.GetComponent<TMP_Text>();
    }
    void Update()
    {
        switch(text)
        {
            case textChose.id:
                tmpText.text = playerData.p_id;
                break;
            case textChose.name:
                tmpText.text = playerData.p_name;
                break;
            case textChose.ap:
                CheckColorChangeAP();
                tmpText.text = playerData.p_ap.ToString();
                break;
            case textChose.exp:
                tmpText.text = playerData.p_exp.ToString();
                break;
            case textChose.shards:
                tmpText.text = playerData.p_shards.ToString("#,#");
                break;
            case textChose.crystals:
                tmpText.text = playerData.p_crystals.ToString("#,#");
                break;
            case textChose.maxAp:
                tmpText.text = playerData.p_maxAp.ToString();
                break;
            case textChose.maxExp:
                tmpText.text = playerData.p_maxExp.ToString();
                break;
            case textChose.numLevel:
                tmpText.text = playerData.p_level.ToString();
                break;
        }
    }
    /// <summary>
    /// Change the AP color, to know whether the current value is higher than the max.
    /// </summary>
    private void CheckColorChangeAP()
    {
        if (playerData.p_ap > playerData.p_maxAp)
        {
            //tmpText.color = new Vector4(0, 0, 0, 255);
            tmpText.color = new Vector4(0, 170, 255, 255);
        }
        else
        {
            tmpText.color = Color.white;
        }
    }

}
