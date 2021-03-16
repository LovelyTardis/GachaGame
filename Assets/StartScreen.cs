using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public Animator Fade;

    public void ExecuteLoad()
    {
        Fade.SetTrigger("Start");
    }
    
}
