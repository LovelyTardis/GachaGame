using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BorderController", menuName = "Scriptable Objects/New BorderController")]
public class BorderController : ScriptableObject
{
   public Sprite defaulBorder;
   [Header("Character Borders")]
   public Sprite bronzeBorder;
   public Sprite silverBorder;
   public Sprite goldBorder;

   public Sprite SetBorder(Character ch)
   {
      Sprite _border = defaulBorder;
      switch (ch.charStars)
      {
         case 1:
         case 2:
            _border = bronzeBorder;
            break;
         case 3:
         case 4:
            _border = silverBorder;
            break;
         case 5:
            _border = goldBorder;
            break;
      }
      return _border;
   }

   public Sprite SetBorder(GameObject go)
   {
      Sprite _border = defaulBorder;
      return _border;
   }
}
