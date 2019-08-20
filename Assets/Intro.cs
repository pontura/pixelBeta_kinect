using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject triviaPanel;
    public KinectManager kinectManager;

    void Start()
    {
        triviaPanel.SetActive(true);
        tutorial.SetActive(false);
        Events.OnUserStatus += OnUserStatus;
        Events.OnButtonClicked += OnButtonClicked;
    }
    private void OnDestroy()
    {
        Events.OnUserStatus -= OnUserStatus;
        Events.OnButtonClicked -= OnButtonClicked;
    }
    void OnButtonClicked(UIInteractiveObject button)
    {
       if (button.field.text == "1")
            Clicked(1);
       else
            Clicked(2);
    }
    void OnUserStatus(bool isOn)
    {
        if(isOn)
        {
            triviaPanel.SetActive(true);
            tutorial.SetActive(false);
        }
        else
        {
            triviaPanel.SetActive(false);
            tutorial.SetActive(true);
        }
    }
    void Clicked(int id)
    {
        Destroy(kinectManager.gameObject);

        if (id==1)
            Data.Instance.LoadLevel("Game");
        else
            Data.Instance.LoadLevel("Game2");
    }

}
