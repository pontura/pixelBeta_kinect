using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager mInstance = null;
    public Character character;

    public gameTypes gameType;
    public enum gameTypes
    {
        SWIMMER,
        WALKER
    }

    public states state;
    public enum states
    {
        INTRO,
        SWIM,
        TRIVIA
    }
    public static UIManager Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
    void Start()
    {
        Events.OnReset();
        SetState(state);
    }
    void Win()
    {
        UIManager.Instance.SetState(UIManager.states.TRIVIA);
    }
    public void SetState(states _state)
    {
        Events.SetChronometer(false, 0);
        this.state = _state;

        character.Show(false);

        if (state == states.TRIVIA)
        {
            Events.StartTrivia();          
        }
        else if (state == states.SWIM)
        {
            Events.StartSwiming();
            character.Show(true);
        }
    }
   

}
