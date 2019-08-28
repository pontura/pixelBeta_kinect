using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void Init()
    {
        panel.SetActive(true);
        StartCoroutine(Done());
        
    }
    IEnumerator Done()
    {
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }
}
