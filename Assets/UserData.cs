using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public int score;
    public states state;
    public enum states
    {
        PLAYING,
        WIN,
        LOSE
    }
    void Start()
    {
        Events.OnScore += OnScore;
        Events.OnGameOver += OnGameOver;
        Events.OnReset += OnReset;
    }
    void OnReset()
    {
        state = states.PLAYING;
        score = 0;
    }
    void OnGameOver(states _state)
    {
        state = _state;
        if (UIManager.Instance.gameType == UIManager.gameTypes.SWIMMER)
            Data.Instance.LoadLevel("SwimSummary");
        else
            Data.Instance.LoadLevel("WalkSummary");
    }
    void OnScore(int _score)
    {
        this.score += _score;
    }
}
