using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    public Text scoreField;

    public gameTypes gameType;
    public enum gameTypes
    {
        SWIMMER,
        WALKER
    }

    void Start()
    {
        if(Data.Instance.userData.state == UserData.states.WIN)
        {
            Win.SetActive(true);
            Lose.SetActive(false);
        }
        else
        {
            Win.SetActive(false);
            Lose.SetActive(true);
        }
        scoreField.text = Utils.FormatNumbers(Data.Instance.userData.score);
        Invoke("Reset", 12);
    }

    void Reset()
    {
        if(gameType == gameTypes.SWIMMER)
            Data.Instance.LoadLevel("Game");   
        else
            Data.Instance.LoadLevel("Game2");
    }
}
