using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Character character;
    public float speed;
    [HideInInspector]
    public float desaceleration = 3;
    public Animator anim;
    public hands hand;
    public enum hands
    {
         LEFT,
         RIGHT
    }
    float hand_distances = 0.8f;

    void Start()
    {
        character = GetComponent<Character>();
        hand_distances = Data.Instance.settings.settingsData.hand_distances;
    }
    public void Reset()
    {
        anim.speed = 0;
        speed = 0;
    }
    void Update()
    {
       if( UIManager.Instance.state == UIManager.states.TRIVIA || UIManager.Instance.state == UIManager.states.INTRO)
            return;

        if (InteractionManager.Instance == null)
            return;

        float left_y = InteractionManager.Instance.GetLeftHandScreenPos().y;
        float right_y = InteractionManager.Instance.GetRightHandScreenPos().y;

        float diff = 0;
        if (left_y > right_y)
            diff = left_y - right_y;
        else diff = right_y - left_y;

        if (diff > hand_distances)
        {
            if (left_y > right_y && hand == hands.RIGHT)
            {
                anim.Play("left");
                AddSpeed(1);
                hand = hands.LEFT;
            }
            else if (left_y < right_y && hand == hands.LEFT)
            {
                AddSpeed(1);
                hand = hands.RIGHT;
                anim.Play("right");
            }
        }

        speed -= desaceleration * Time.deltaTime;

        if (speed < 0)
        {
            speed = 0;
        }
        else if (speed > 10)
            speed = 10;

        float LastSpeed = speed / 1.5f;
        if (LastSpeed > 1)
            LastSpeed = 1;
        anim.speed = LastSpeed;

        character.SetSpeed(speed);
    }
    public void AddSpeed(float qty)
    {
        speed += qty;
    }
}
