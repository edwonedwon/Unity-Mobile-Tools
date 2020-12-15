using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenTouchEventRelay : ScreenTouchEventReceiverBase
{
    public UnityEvent onTouchBegin;
    public UnityEvent onTouchUpdate;
    public UnityEvent onTouchEnd;

    public override void OnTouchBegin(Vector2 screenPos)
    {
        onTouchBegin.Invoke();
    }

    public override void OnTouchUpdate(Vector2 screenPos)
    {
        onTouchUpdate.Invoke();
    }

    public override void OnTouchEnd(Vector2 screenPos)
    {
        onTouchEnd.Invoke();
    }
}
