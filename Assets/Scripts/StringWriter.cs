using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StringWriter : MonoBehaviour
{
    /*
    [SerializeField]
    private TMP_Text textoCanvas;
    [SerializeField]
    private GameObject panelDialogo;
    private string theText;
    public float speed = 0.1f;
    private string currentText = "";
    private bool dialogoactivo = false;
    //private Player theplayer;
    public void StartText(string fullText)
    {
        if (dialogoactivo)
        {
            CerrarDialogo();
        }
        else
        {
            //Player.player.status = 2;
            panelDialogo.SetActive(true);
            theText = fullText;
            StartCoroutine(ShowText());
        }
    }
    IEnumerator ShowText()
    {
        yield return null;
        if (!dialogoactivo)
        {
            dialogoactivo = true;
            for (int i = 0; i < theText.Length; i++)
            {
                if (dialogoactivo)
                {
                    currentText = theText.Substring(0, i);
                    textoCanvas.text = currentText;
                    yield return new WaitForSeconds(speed);
                }
                else yield return new WaitForSeconds(0.4f);
            }
        }
        else yield break;
    }
    private void CerrarDialogo()
    {
        StopCoroutine(ShowText());
        currentText = "";
        theText = "";
        textoCanvas.text = "";
        dialogoactivo = false;
        panelDialogo.SetActive(false);
        //Player.player.status = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CerrarDialogo();
        }
    }*/
}
