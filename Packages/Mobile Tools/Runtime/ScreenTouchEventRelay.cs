using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Edwon.MobileTools
{
    public class ScreenTouchEventRelay : ScreenTouchEventReceiverBase
    {
        [Header("to prevent events getting called on awake")]
        public bool ignoreOnAwake = true;
        bool awakeFrame = true;

        public UnityEvent onTouchBegin;
        public UnityEvent onTouchUpdate;
        public UnityEvent onTouchEnd;

        void Awake()
        {
            if (ignoreOnAwake)
                awakeFrame = true;
        }

        void Update()
        {
            awakeFrame = false;
        }

        public override void OnTouchBegin(Vector2 screenPos)
        {
            if (ignoreOnAwake && awakeFrame)
                return;

            onTouchBegin.Invoke();
        }

        public override void OnTouchUpdate(Vector2 screenPos)
        {
            if (ignoreOnAwake && awakeFrame)
                return;

            onTouchUpdate.Invoke();
        }

        public override void OnTouchEnd(Vector2 screenPos)
        {
            if (ignoreOnAwake && awakeFrame)
                return;

            onTouchEnd.Invoke();
        }
    }
}