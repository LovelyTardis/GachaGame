using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSlotManager : MonoBehaviour
{
   public List<GameObject> slotContainer;
   public GameObject slotPrefab;
   [Range(0f,1f)]
   public float timeSpawn;

   public GameObject backButton;
   public void LoadSlots(List<Character> pullList) // for characters
   {
      //Esto solo vacia los gameobjects xdd
      foreach (GameObject slot in slotContainer)
      {
         foreach (Transform child in slot.transform)
         {
            Destroy(child.gameObject);
         }
      }
      StartCoroutine(LoadAllSlots(pullList));
   }

   IEnumerator LoadAllSlots(List<Character> pullList)
   {
      for (int x = 0; x < pullList.Count; x++)
      {
         GameObject slotCharacter = Instantiate(slotPrefab, slotContainer[x].transform, false); 
         slotCharacter.GetComponent<UIGachaSlot>().LoadSlot(pullList[x]);
         yield return new WaitForSeconds(timeSpawn);
      }
      backButton.SetActive(true);
   }
}
