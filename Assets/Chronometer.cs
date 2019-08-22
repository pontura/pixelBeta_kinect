using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    public GameObject panel;
    Animation anim;
    bool isOn;
    float totalTime;
    float initialTime;
    public Image bar;
    public Image center;
    public Text field;
    public float value;

    Color centerDefault;

    void Start()
    {
        Events.SetChronometer += SetChronometer;
        centerDefault = center.color;
        panel.SetActive(false);
        anim = panel.GetComponent<Animation>();
    }
    private void OnDestroy()
    {
        Events.SetChronometer -= SetChronometer;
    }
    void SetChronometer(bool _isOn, float totalTime = 0)
    {
        isOn = _isOn;
        panel.SetActive(isOn);
        if (!isOn)
            return;

        initialTime = Time.time;
        this.totalTime = totalTime;
        center.color = Color.black;
    }
    string lastSec;
    void Update()
    {
        if (!isOn)
            return;

        float resto = Time.time - initialTime;
       
        value = resto / totalTime;
        bar.fillAmount = 1 - value;

        string stringValue = "";
        float seg = totalTime - resto;
        if (seg < 10)
            stringValue = "0" + (int)seg;
        else
            stringValue = ((int)seg).ToString();

        if(stringValue != lastSec)
        {
            anim.Play("chronometer_on");
        }
        lastSec = stringValue;

        field.text = stringValue;

        if (resto >= totalTime)
        {
            anim.Play("chronometer_complete");
            isOn = false;
            field.text = "0";
            bar.fillAmount = 0;
            center.color = Color.red;       
            Events.OnUIFX("timeout");
            Events.OnTimeOut();
            Pause();
        }
    }

    public void Pause() {
        isOn = false;
    }
}
