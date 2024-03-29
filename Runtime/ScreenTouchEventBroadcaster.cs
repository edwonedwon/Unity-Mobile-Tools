﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#if EDWON_LEANTOUCH
using Lean.Touch;
#endif

namespace Edwon.MobileTools
{
    public class ScreenTouchEventBroadcaster : MonoBehaviour
    {
        public delegate void OnTouchBeginEvent(Vector2 _screenPos);
        public delegate void OnTouchUpdateEvent(Vector2 _screenPos, bool startedOverGui); 
        public delegate void OnTouchEndEvent(Vector2 _screenPos, bool startedOverGui);
        public static OnTouchBeginEvent onTouchBegin;
        public static OnTouchUpdateEvent onTouchUpdate;
        public static OnTouchEndEvent onTouchEnd;

        public bool debugLog;

        #if EDWON_LEANTOUCH
        void OnTouchBegin(LeanFinger finger)
        {
            if (finger.IsOverGui)
                return;

            if (debugLog)
                Debug.Log("OnTouchBegin: " + finger.ScreenPosition + " frame: " + Time.frameCount);

            if (onTouchBegin != null)
                onTouchBegin(finger.ScreenPosition);
        }

        public void OnTouchUpdate(LeanFinger finger)
        {
            if (finger.IsOverGui)
                return;

            if (debugLog)
                Debug.Log("OnTouchUpdate: " + finger.ScreenPosition + " frame: " + Time.frameCount);

            if (onTouchUpdate != null)
                onTouchUpdate(finger.ScreenPosition, finger.StartedOverGui);
        }

        public void OnTouchEnd(LeanFinger finger)
        {
            if (finger.IsOverGui)
                return;
                
            if (debugLog)
                Debug.Log("OnTouchEnd: " + finger.ScreenPosition + " frame: " + Time.frameCount);

            if (onTouchEnd != null)
                onTouchEnd(finger.ScreenPosition, finger.StartedOverGui);
        }
        #endif

        void OnEnable()
        {
            #if EDWON_LEANTOUCH
            LeanTouch.OnFingerDown += OnTouchBegin;
            LeanTouch.OnFingerUpdate += OnTouchUpdate;
            LeanTouch.OnFingerUp += OnTouchEnd;
            #endif
        }

        void OnDisable()
        {
            #if EDWON_LEANTOUCH
            LeanTouch.OnFingerDown -= OnTouchBegin;
            LeanTouch.OnFingerUpdate -= OnTouchUpdate;
            LeanTouch.OnFingerUp -= OnTouchEnd;
            #endif
        }
    }
}