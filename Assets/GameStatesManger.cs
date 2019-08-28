using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesManger : MonoBehaviour
{
    public GameObject state0;
    public GameObject state1;
    public GameObject state2;
    public GameObject state3;

    void Start()
    {
        Reset();
        Events.EndTrivia += EndTrivia;
        state0.SetActive(true);
    }
    void OnDestroy()
    {
        Events.EndTrivia -= EndTrivia;
    }
    public void EndTrivia()
    {
        int winNum = UIManager.Instance.GetComponent<Trivia>().winNum;


        Reset();
        if (winNum < 2)
            state1.SetActive(true);
        else if (winNum == 2)
            state2.SetActive(true);
        else if (winNum == 3)
            state3.SetActive(true);
    }
    void Reset()
    {
        state0.SetActive(false);
        state1.SetActive(false);
        state2.SetActive(false);
        state3.SetActive(false);

    }
}
