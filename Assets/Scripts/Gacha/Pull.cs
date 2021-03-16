using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pull : MonoBehaviour
{
    public static int pullValue;

    public void pull(int numOfPulls)
    {
        //FALTA IMPLEMENTAR EL PRECIO
        pullValue = numOfPulls;
        SceneManager.LoadScene("GachaScene",LoadSceneMode.Additive);
    }
}
