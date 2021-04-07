using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattleSlot : MonoBehaviour
    {
        public Image cImage;
        public Character ch;
        public static int lastSkillUsed = 0;
        public static string path = "";
        public List<Button> habButtons;
        public bool used = false;
        public void LoadSlot()
        {
            if (ch != null)
                ch.LoadUICharacter(this);
        }
        public void ButtonEffect(int ability)
        {
            lastSkillUsed = ability;
            path = "Characters/" +ch.charName;
            Debug.Log("Skill Used: "+lastSkillUsed+ ", FilePath: "+path);
        }
        public void SwapButtons(bool value)
        {
            foreach (Button btn in habButtons)
            {
                btn.interactable = value;
            }
        }
    }
}
