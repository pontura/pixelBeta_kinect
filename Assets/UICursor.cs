using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursor : MonoBehaviour
{
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        Events.ShowCursor += ShowCursor;
    }
    void OnDestroy()
    {
        Events.ShowCursor -= ShowCursor;
    }
    void ShowCursor(bool isOn)
    {
        image.enabled = isOn;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        SetOver(true, collision);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        SetOver(false, collision);
    }
    void SetOver(bool isOver, Collider2D collision)
    {
        UIInteractiveObject uiInteractiveObject = collision.gameObject.GetComponent<UIInteractiveObject>();
        if (uiInteractiveObject != null)
            uiInteractiveObject.OnOver(isOver);
    }
}
