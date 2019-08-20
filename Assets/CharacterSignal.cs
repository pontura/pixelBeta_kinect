using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSignal : MonoBehaviour
{
    public Text field;
    public GameObject panel;

    public void Init(string text)
    {
        panel.gameObject.SetActive(true);
        field.text = text;
    }
    public void SetOff()
    {
        panel.gameObject.SetActive(false);
    }
}
