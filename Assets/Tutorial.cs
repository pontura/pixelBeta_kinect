using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public states state;
    public enum states
    {
        IDLE,
        ON_CENTER,
        DONE
    }
    public GameObject panel;
    
    
    bool isOn;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public KinectManager kinectManager;

    void Start()
    {
       
        Events.OnUserStatus += OnUserStatus;
        SetOn();
    }
    private void OnDestroy()
    {
        Events.OnUserStatus -= OnUserStatus;
    }
    void OnUserStatus(bool isOn)
    {
        if(isOn)
        {
            state = states.ON_CENTER;
            SetTutorialState();
        } else
        {
            Destroy(kinectManager.gameObject);
            if(UIManager.Instance.gameType == UIManager.gameTypes.SWIMMER)
                Data.Instance.LoadLevel("Game");
            else
                Data.Instance.LoadLevel("Game2");
        }
    }
    public void SetOn()
    {
        state = states.IDLE;
        SetTutorialState();
       
        panel.SetActive(true);
    }
    public void Reset()
    {
        panel.SetActive(false);

        if(UIManager.Instance.gameType == UIManager.gameTypes.SWIMMER)
            UIManager.Instance.SetState(UIManager.states.SWIM);
        else if (UIManager.Instance.gameType == UIManager.gameTypes.WALKER)
            UIManager.Instance.SetState(UIManager.states.TRIVIA);

        state = states.DONE;
    }
    void Update()
    {
        if(state == states.ON_CENTER)
        {
            if (InteractionManager.Instance == null)
                return;
            float left_y = InteractionManager.Instance.GetLeftHandScreenPos().y;
            float right_y = InteractionManager.Instance.GetRightHandScreenPos().y;

            if(left_y>0.8f && right_y> 0.8f)
                Reset();
        }
    }
    void SetTutorialState()
    {
        if(state == states.IDLE)
        {
            tutorial1.SetActive(true);
            tutorial2.SetActive(false);
        }
        else
        {
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
        }
    }
}
