using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void DisableScene()
    {
        SceneManager.UnloadSceneAsync("GachaScene",UnloadSceneOptions.None);
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
