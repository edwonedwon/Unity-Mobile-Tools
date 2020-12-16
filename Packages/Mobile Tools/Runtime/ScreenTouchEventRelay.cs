using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Edwon.MobileTools
{
    public class ScreenTouchEventRelay : ScreenTouchEventReceiverBase
    {
        public bool ignoreTouchEventsOnAwakeFrame = true;
        bool awakeFrame = true;

        public UnityEvent onTouchBegin;
        public UnityEvent onTouchUpdate;
        public UnityEvent onTouchEnd;

        void Awake()
        {
            if (ignoreTouchEventsOnAwakeFrame)
                awakeFrame = true;
        }

        void Update()
        {
            awakeFrame = false;
        }

        public override void OnTouchBegin(Vector2 screenPos)
        {
            if (ignoreTouchEventsOnAwakeFrame && awakeFrame)
                return;

            onTouchBegin.Invoke();
        }

        public override void OnTouchUpdate(Vector2 screenPos)
        {
            if (ignoreTouchEventsOnAwakeFrame && awakeFrame)
                return;

            onTouchUpdate.Invoke();
        }

        public override void OnTouchEnd(Vector2 screenPos)
        {
            if (ignoreTouchEventsOnAwakeFrame && awakeFrame)
                return;

            onTouchEnd.Invoke();
        }
    }
}