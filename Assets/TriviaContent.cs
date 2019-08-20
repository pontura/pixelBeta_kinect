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
    void Start()
    {
        StartCoroutine(Load());
    }
    public IEnumerator Load()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "trivia.json");
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
