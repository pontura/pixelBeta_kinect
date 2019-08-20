using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject bar;
    public GameObject button;
    public Text field;

    public int barMaxValue = -4169;
    public int buttonMaxValue = 1340;

    public void SetProgress(float value)
    {
        if (value < -10000 || value > 10000)
            return;
        Vector3 pos =  bar.transform.localPosition;
        pos.y = value * barMaxValue;
        bar.transform.localPosition = pos;
            
        pos = button.transform.localPosition;
        pos.y = value * buttonMaxValue;
        button.transform.localPosition = pos;
        field.text = (int)(value * 100) + "%";
    }
}
