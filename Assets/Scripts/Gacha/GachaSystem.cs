using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class GachaSystem : MonoBehaviour
{
    public bool guaranteed2Star;
    public bool guaranteed3Star;
    public abstract void OnPull(int nOfPulls);
    
}
