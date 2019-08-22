using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TriviaContent : MonoBehaviour
{
    public AllTriviaData all;
    [Serializable]
    public class AllTriviaData
    {
        public List<TriviaData> data;
    }
    [Serializable]
    public class TriviaData
    {
        public string pregunta;
        public string respuesta_1;
        public string respuesta_2;
        public string respuesta_3;
    }
    public void Init(int id)
    {
        if(id == 1)
          StartCoroutine(Load("trivia"));
        else
          StartCoroutine(Load("trivia2"));
    }
    public IEnumerator Load(string triviaName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, triviaName + ".json");
        string dataAsJson;
        print(filePath);
        if (filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            dataAsJson = www.text;
        }
        else
        {
            dataAsJson = File.ReadAllText(filePath);
        }
        all = JsonUtility.FromJson<AllTriviaData>(dataAsJson);
    }
}
