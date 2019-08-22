using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{
    Chronometer chronometer;
    public GameObject panel;
    public TriviaContent.TriviaData data;
    Animation anim; 
    public Text title;
    public UIInteractiveObject[] buttons;
    bool isOn;
    public int wrongNum;
    public int winNum;

    void Start()
    {
        chronometer = GetComponent<Chronometer>();
        anim = panel.GetComponent<Animation>();
        Events.StartTrivia += StartTrivia;
        Events.OnButtonClicked += OnButtonClicked;
        Events.OnTimeOut += OnTimeOut;
        Events.OnReset += OnReset;
        SetOff();

        if(UIManager.Instance.gameType == UIManager.gameTypes.SWIMMER)
            Data.Instance.GetComponent<TriviaContent>().Init(1);
        else
            Data.Instance.GetComponent<TriviaContent>().Init(2);
    }
    void OnDestroy()
    {
        Events.StartTrivia -= StartTrivia;
        Events.OnButtonClicked -= OnButtonClicked;
        Events.OnTimeOut -= OnTimeOut;
        Events.OnReset -= OnReset;
    }
    void OnReset()
    {
        wrongNum = 0;
        winNum = 0;
    }
    void End()
    {
        SetOff();
        if (winNum >= 3)
        {
            Events.EndTrivia();
            anim.Play("triviaOff");
            Events.OnGameOver(UserData.states.WIN);
        }
        else
        {
            UIManager.Instance.SetState(UIManager.states.SWIM);
        }
    }
    void SetOff()
    {
        panel.SetActive(false);
    }
    void StartTrivia()
    {
        Events.ShowCursor(true);
        panel.SetActive(true);
        Init();
    }
    void OnTimeOut()
    {
        if (!isOn)
            return;
        Invoke("TimeOutDelay", 0.5f);
    }
    void TimeOutDelay()
    {
        OnButtonClicked(null);
    }
    void Init()
    {
        chronometer.Pause();
        isOn = true;
        data = Data.Instance.triviaAdmin.GetQuestion();
        title.text = data.pregunta;
        Shuffle();
        buttons[0].Init(data.respuesta_1);
        buttons[1].Init(data.respuesta_2);
        buttons[2].Init(data.respuesta_3);
        StartCoroutine(Started());
    }
    IEnumerator Started()
    {        
        yield return new WaitForSeconds(1);
        Events.SetChronometer(true, Data.Instance.settings.settingsData.triviaTime);
    }
    void OnResult(bool win)
    {
        chronometer.Pause();
        float v = 1-chronometer.value;
        int score = (int)(v * 1000);
        if (!win)
            score = 0;
        Events.OnScore(score);

    }
    bool win;
    
    void OnButtonClicked(UIInteractiveObject button)
    {
        if (!isOn)
            return;

        win = false;
        if (button == null)
        {
            OnResult(false);
        }
        else if (button.field.text == data.respuesta_1)
        {
            win = true;
            OnResult(true);
            button.SetResult(true);
        }
        else
        {
            OnResult(false);
            button.SetResult(false);
        }
        Events.SetChronometer(false, 0);
        isOn = false;
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(0.7f);
        if (win)
        {
            winNum++;
            GetComponent<WinPanel>().Init();
            Events.EndTrivia();
            anim.Play("triviaOff");
            yield return new WaitForSeconds(2f);
            End();
        }  else
        {
            wrongNum++;
            if (wrongNum < 3)
            {
                GetComponent<WrongPanel>().Init();
                anim.Play("trivia_change");
                yield return new WaitForSeconds(2);
                Init();
                yield return new WaitForSeconds(0.5f);
                anim.Play("trivia_appear");
            }
            else
            {
                Events.EndTrivia();
                anim.Play("triviaOff");
                Events.OnGameOver(UserData.states.LOSE);
            }
        }
        
    }
    public void Shuffle()
    {
        if (buttons.Length < 2) return;
        for (int a = 0; a < 10; a++)
        {
            int id = Random.Range(1, buttons.Length);
            UIInteractiveObject value1 = buttons[0];
            UIInteractiveObject value2 = buttons[id];
            buttons[0] = value2;
            buttons[id] = value1;
        }
    }
    
}