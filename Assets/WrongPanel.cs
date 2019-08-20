using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongPanel : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }
    
    public void Init(bool lastOne = false)
    {
        if (lastOne)
        {
            Events.OnGameOver(UserData.states.LOSE);
            return;
        }
        panel.SetActive(true);
        StartCoroutine(Done());      
    }
    IEnumerator Done()
    {
        yield return new WaitForSeconds(1.5f);
        //carga swim...
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }
}
