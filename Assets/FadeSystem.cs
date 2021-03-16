using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeSystem : MonoBehaviour
{
    public Image Fade;
    public void OnFadeFinish()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void DisableRayCast()
    {
        Fade.raycastTarget = false;
    }
}
