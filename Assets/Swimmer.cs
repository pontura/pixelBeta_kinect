using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    public float factor;
    public GameObject handLeft;
    public GameObject handRiht;
    public GameObject panel;

    void Update()
    {
        if (UIManager.Instance.state == UIManager.states.TRIVIA)
            return;
        if (InteractionManager.Instance == null)
            return;
        float left_y = InteractionManager.Instance.GetLeftHandScreenPos().y;
        float right_y = InteractionManager.Instance.GetRightHandScreenPos().y;
        Swim(left_y, right_y);
    }
    void Swim(float left_y, float right_y)
    {
        handLeft.transform.localPosition = new Vector2(handLeft.transform.localPosition.x, left_y*factor);
        handRiht.transform.localPosition = new Vector2(handRiht.transform.localPosition.x, right_y * factor);
    }
}
