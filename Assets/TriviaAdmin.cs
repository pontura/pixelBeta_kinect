using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaAdmin : MonoBehaviour
{
    TriviaContent content;
    public int id;

    void Start()
    {
        content = GetComponent<TriviaContent>();
    }
    public TriviaContent.TriviaData GetQuestion()
    {
        TriviaContent.TriviaData data = content.all.data[id];
        if (id >= content.all.data.Count-1)
            id = 0;
        else
            id++;
        return data;
    }
}
