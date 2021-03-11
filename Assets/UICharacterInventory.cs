using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterInventory : MonoBehaviour
{
    public GameObject charactersUnlocked;

    public GameObject charactersLocked;

    public void Sort()
    {
        foreach (UICharacterSlot Slot in charactersUnlocked.GetComponentsInChildren<UICharacterSlot>())
        {
            if (Slot.locked)
                Slot.gameObject.transform.SetParent(charactersLocked.transform,false);
            else
                Slot.gameObject.transform.SetParent(charactersUnlocked.transform,false);
        }
        foreach (UICharacterSlot Slot in charactersLocked.GetComponentsInChildren<UICharacterSlot>())
        {
            if (Slot.locked)
                Slot.gameObject.transform.SetParent(charactersLocked.transform,false);
            else
                Slot.gameObject.transform.SetParent(charactersUnlocked.transform,false);
        }
    }
}
