using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGachaSlot : MonoBehaviour
{
    public List<Image> stars;
    public Sprite ActiveStar;
    public Sprite UnactiveStar;
    
    public Image slotImage;
    public Image slotBorder;
    [SerializeField]
    private Character character;
    public BorderController bc;
    public GameObject newText;
    public void LoadSlot(Character ch)
    {
        character = ch;
        slotImage.sprite = ch.charImage;
        slotBorder.sprite = bc.SetGoldBorder();
        if (!ch.unlocked)
        {
            ch.unlocked = true;
            newText.SetActive(true);
        }
        LoadStars(ch);
    }
    private void LoadStars(Character ch)
    {
        for (int i = 0; i < stars.Count; i++)
        {
            if(i < ch.charStars)
                stars[i].sprite = ActiveStar;
            else
                stars[i].sprite = UnactiveStar;
        }
    }

}
