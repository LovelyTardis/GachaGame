using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSystem : MonoBehaviour
{
    public bool Secured2star;
    public bool Secured3star;
    public GameObject prefabFrameC1;
    public GameObject prefabFrameC2;
    public GameObject prefabFrameC3;
    public PlayerData playerData;
    public List<Character> c_1star = new List<Character>();
    public List<Character> c_2star = new List<Character>();
    public List<Character> c_3star = new List<Character>();

    public List<GameObject> slots = new List<GameObject>();

    public float c_1starRate;
    public float c_2starRate;
    public float c_3starRate;

    [Range(0f,1f)]
    public float TimeSpawn;

    public bool canpull = true;
    public void Pull(int nOfPulls)
    {
        StartCoroutine(Pul(nOfPulls));
    }


    IEnumerator Pul(int nOfPulls)
    {
        if (canpull)
        {
            // esto es para guardar al acabar la pull si es asegurada o no, esto es para tirar muchas veces xdd
            bool temp1 = Secured2star;
            bool temp2 = Secured3star;
            //
            canpull = false;
            //Esto solo vacia los gameobjects xdd
            foreach (GameObject slot in slots)
            {
                foreach (Transform child in slot.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            //
        
        
            for (int i = 0; i < nOfPulls; i++)
            {
                float nb = Random.Range(0f, 100f);
                if (Secured2star)
                {
                    Secured2star = false;
                    if (nb >= 0 && nb < c_3starRate)
                    {
                        int x = Random.Range(0, c_3star.Count);
                        yield return StartCoroutine(Spawn3(x, i));
                    }
                    else
                    {
                        int x = Random.Range(0, c_2star.Count);
                        yield return StartCoroutine(Spawn2(x, i));
                    }
                }
                else if (Secured3star)
                {
                    Secured3star = false;
                    int x = Random.Range(0, c_3star.Count);
                    yield return StartCoroutine(Spawn3(x, i));
                }
                else 
                {
                    if (nb >= 0 && nb < c_3starRate)
                    {
                        int x = Random.Range(0, c_3star.Count);
                        yield return StartCoroutine(Spawn3(x, i));
                    }
                    else if (nb >= c_3starRate && nb < c_2starRate)
                    {
                        int x = Random.Range(0, c_2star.Count);
                        yield return StartCoroutine(Spawn2(x, i));
                    }
                    else if (nb >= c_2starRate && nb < c_1starRate)
                    {
                        int x = Random.Range(0, c_1star.Count);
                        yield return StartCoroutine(Spawn1(x, i));
                    }
                }
            }
            Secured2star = temp1;
            Secured3star = temp2;
            canpull = true;
        }
    }
    
    
    
    // INTENTAR AGRUPAR TOD0 EN UN SCRIPT////////////////////////////////////////////////////////////////////////
    IEnumerator Spawn3(int x, int i)
    {
        GameObject frameC3 = prefabFrameC3; // hago una copia para editarla

        Image[] images = frameC3.GetComponentsInChildren<Image>();
        foreach (Image img in images)
        {
            if(img.gameObject.transform.parent != null)
            {
                img.sprite = c_3star[x].charImage;
            }
        }

        GameObject l = Instantiate(frameC3, slots[i].transform.position, Quaternion.identity);
        l.transform.SetParent(slots[i].gameObject.transform);
        l.transform.localScale = new Vector3(2,2,2);
        yield return new WaitForSeconds(TimeSpawn);
    }
    
    IEnumerator Spawn2(int x, int i)
    {
        GameObject frameC2 = prefabFrameC2;
        Image[] images = frameC2.GetComponentsInChildren<Image>();
        foreach (Image img in images)
        {
            if(img.gameObject.transform.parent != null)
            {
                img.sprite = c_2star[x].charImage;
            }
        }

        GameObject l = Instantiate(frameC2, slots[i].transform.position, Quaternion.identity);
        l.transform.SetParent(slots[i].gameObject.transform);
        l.transform.localScale = new Vector3(2,2,2);
        yield return new WaitForSeconds(TimeSpawn);
    }
    IEnumerator Spawn1(int x, int i)
    {
        GameObject frameC1 = prefabFrameC1;
        Image[] images = frameC1.GetComponentsInChildren<Image>();
        foreach (Image img in images)
        {
            if(img.gameObject.transform.parent != null)
            {
                img.sprite = c_1star[x].charImage;
            }
        }
        
        GameObject l = Instantiate(frameC1, slots[i].transform.position, Quaternion.identity);
        l.transform.SetParent(slots[i].gameObject.transform);
        l.transform.localScale = new Vector3(2,2,2);
        yield return new WaitForSeconds(TimeSpawn);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////
}
