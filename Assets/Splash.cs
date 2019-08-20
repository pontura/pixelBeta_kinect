using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    void Start()
    {
        Invoke("Init", 0.5f);
    }

    void Init()
    {
        Data.Instance.LoadLevel("VideoPlayer");
    }
}
