using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSlotManager : MonoBehaviour
{
   public List<GameObject> SlotContainer;
   public GameObject SlotPrefab;
   public void LoadSlots(List<Character> PullList) // for characters
   {
      for (int x = 0; x < PullList.Count; x++)
      {
         GameObject slotCharacter = Instantiate(SlotPrefab, SlotContainer[x].transform, false);
         slotCharacter.GetComponent<SlotCharacter>();
      }
   }
}
