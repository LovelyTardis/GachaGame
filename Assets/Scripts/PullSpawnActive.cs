using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullSpawnActive : MonoBehaviour
{
    public Animator animation;
    void Start()
    {
       animation.SetBool("isActive",true);
    }


}
