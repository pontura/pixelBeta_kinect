using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractiveObject : MonoBehaviour
{
    public GameObject imageIdle;
    public GameObject imageOver;
    public GameObject imageClicked_Ok;
    public GameObject imageClicked_Wrong;
    public bool isOver;
    public Text field;
    bool isClicked;
    private void Start()
    {
        Events.OnClick += OnClick;
        Idle();        
    }
    public void Init(string text)
    {
        isOver = false;
        isClicked = false;
        Idle();
        field.text = text;
    }
    private void OnDestroy()
    {
        Events.OnClick -= OnClick;
    }
    void Idle()
    {        
        imageIdle.SetActive(true);
        imageOver.SetActive(false);
        imageClicked_Ok.SetActive(false);
        imageClicked_Wrong.SetActive(false);
    }
    void Over()
    {
        imageIdle.SetActive(false);
        imageOver.SetActive(true);
        imageClicked_Ok.SetActive(false);
        imageClicked_Wrong.SetActive(false);
    }
    void OnClick()
    {
        if (isClicked)
            return;
        if (isOver)
        {
            isClicked = true;
            Events.OnButtonClicked(this);
            GetComponent<Animation>().Play();
        }
        else if(!isClicked)
        {
            Idle();
        }
    }
    public void SetResult(bool ok)
    {
        if (ok)
        {
            Events.OnUIFX("si");
            imageClicked_Ok.SetActive(true);
        }
        else
        {
            Events.OnUIFX("no");
            imageClicked_Wrong.SetActive(true);
        }

        imageIdle.SetActive(false);
        imageOver.SetActive(false);
    }
    public void OnOver(bool isOver)
    {
        if (isClicked)
            return;
        this.isOver = isOver;
        if (isOver)
            Over();
        else
            Idle();
    }
}
