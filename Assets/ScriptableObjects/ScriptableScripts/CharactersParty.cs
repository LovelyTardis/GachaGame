using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Party",menuName = "Scriptable Objects/New Party")]
public class CharactersParty : ScriptableObject
{
    //public Character[] Characters = new Character[5];
    public List<Character> characters = new List<Character>();
}
