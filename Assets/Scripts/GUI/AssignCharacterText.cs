using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssignCharacterText : MonoBehaviour
{
    private Character character;
    public enum charInfo { name, stars, classSelected }
    public charInfo info;

    private TMP_Text text;

    private void Start()
    {
        character = gameObject.GetComponentInParent<Test>().ch;
        text = gameObject.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        switch(info)
        {
            case charInfo.name:
                text.text = character.charName;
                break;
            case charInfo.stars:
                text.text = character.charStars.ToString();
                break;
            case charInfo.classSelected:
                text.text = character.charClass.ToString();
                break;
        }
    }
}
