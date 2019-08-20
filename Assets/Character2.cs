using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2 : Character
{
    int total_x = 290;
    int lastWinID = 0;
    CharacterSignal characterSignal;
    
    public override void StartSwiming()
    {
        base.StartSwiming();

        characterSignal = GetComponent<CharacterSignal>();
        int winNum = UIManager.Instance.GetComponent<Trivia>().winNum;

        if (lastWinID != winNum)
        {
            if(winNum == 1)
                characterSignal.Init("Completaste la primer etapa");
            else
                characterSignal.Init("Completaste la segunda etapa");

            lastWinID = winNum;
            Invoke("TurnOffSignal", 3);
        }
        else
        {
            characterSignal.SetOff();
        }
        
        progressBar.gameObject.SetActive(true);
        
        NewRonda();
        speed = Data.Instance.settings.settingsData.walkerSpeed / 500;
    }
    void TurnOffSignal()
    {
        characterSignal.SetOff();
    }
    public void NewRonda()
    {
        int winRonda = UIManager.Instance.GetComponent<Trivia>().winNum - 1;
        if (winRonda < 0)
            winRonda = 0;
        int initial = winRonda * total_x;
        from_to = new Vector2(initial, total_x + initial);
        Vector3 pos = transform.localPosition;
        pos.x = initial;
        transform.localPosition = pos;
    }
    public override void SetSpeed(float newSpeed)
    {
        Vector3 pos = transform.localPosition;
        pos.x += newSpeed * speed;

        if (progressBar != null)
            progressBar.SetProgress(pos.x / from_to[1]);
    

        if (pos.x > from_to[1])
        {
            pos.x = from_to[1];
            progressBar.gameObject.SetActive(false);
            Win();
        }
        transform.localPosition = pos;
    }
}
