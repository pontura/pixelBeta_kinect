using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject andaniveles;
    public ProgressBar progressBar;
    public Vector2 from_to;
    public float speed;
    AnimationController animationController;
    public bool isOn;
    public GameObject asset_ui;

    void Start()
    {       
        animationController = GetComponent<AnimationController>();
        Events.OnSettingsDone += OnSettingsDone;
        Events.StartSwiming += StartSwiming;
        Events.EndTrivia += EndTrivia;
        Events.OnTimeOut += OnTimeOut;
        OnSettingsDone();
    }
    void OnTimeOut()
    {
        if (!isOn)
            return;
       // Events.OnGameOver(UserData.states.LOSE);
    }
    public void Show(bool isOn)
    {
        transform.gameObject.SetActive(isOn);
        if(andaniveles != null)
             andaniveles.gameObject.SetActive(isOn);
        if(asset_ui != null)
            asset_ui.gameObject.SetActive(isOn);
    }
    void OnSettingsDone()
    {
        animationController.desaceleration = Data.Instance.settings.settingsData.desaceleration;
        StartSwiming();
    }
    void EndTrivia()
    {
        transform.localPosition = Vector3.zero;
    }
    public virtual void StartSwiming()
    {
        isOn = true;
        Events.ShowCursor(false);
       // Events.SetChronometer(true, Data.Instance.settings.settingsData.swimTime);
        transform.localPosition = Vector3.zero;
        speed = Data.Instance.settings.settingsData.swimmerSpeed / 10000;        
    }
    private void OnDestroy()
    {
        Events.OnSettingsDone -= OnSettingsDone;
        Events.StartSwiming -= StartSwiming;
        Events.EndTrivia -= EndTrivia;
        Events.OnTimeOut -= OnTimeOut;
    }    
    public virtual void SetSpeed(float newSpeed)
    {        
        Vector3 pos = transform.localPosition;
        pos.y += newSpeed*speed;

        if(progressBar != null)
            progressBar.SetProgress(pos.y / from_to[1]);


        if (pos.y > from_to[1])
        {
            pos.y = from_to[1];
            
            Win();
        }
        transform.localPosition = pos;
    }
    public void Win()
    {
        animationController.Reset();
        isOn = false;
        UIManager.Instance.SetState(UIManager.states.TRIVIA);
    }

}
