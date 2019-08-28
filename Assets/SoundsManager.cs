using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource audiosSource;

    public AudioClip si;
    public AudioClip no;
    public AudioClip timeout;
    public AudioClip nada;
    public AudioClip gana;
    public AudioClip pierde;
    public AudioClip camina;

    void Start()
    {
        Events.OnUIFX += OnUIFX;
    }

    void OnUIFX(string name)
    {
        AudioClip clip = null;
        switch (name)
        {
            case "si":
                clip = si;
                break;
            case "no":
                clip = no;
                break;
            case "timeout":
                clip = timeout;
                break;
            case "nada":
                clip = nada;
                break;
            case "gana":
                clip = gana;
                break;
            case "pierde":
                clip = pierde;
                break;
            case "camina":
                clip = camina;
                break;
        }
        if (clip == null)
            return;

        audiosSource.clip = clip;
        audiosSource.Play();
    }
}
