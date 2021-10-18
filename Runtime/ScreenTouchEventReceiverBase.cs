using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edwon.MobileTools
{
    public abstract class ScreenTouchEventReceiverBase : MonoBehaviour
    {
        public bool debugLog;
        [Header("Will only ivoke if touch started over UI")]
        public bool invokeOnlyIfStartedOverGui = false;
        [Header("Will only invoke Update and End if this object was present when touch began")]
        public bool invokeOnlyIfWholeLifecycle = true;
        bool touchBegan = false;

        public abstract void OnTouchBegin(Vector2 screenPos);
        public abstract void OnTouchUpdate(Vector2 screenPos);
        public abstract void OnTouchEnd(Vector2 screenPos);

        void OnTouchBeginEvent(Vector2 screenPos)
        {
            if (debugLog)
                Debug.Log(gameObject.name + " " + this.GetType().Name + " OnTouchBegin");

            OnTouchBegin(screenPos);

            touchBegan = true;
        }

        void OnTouchUpdateEvent(Vector2 screenPos, bool startedOverGUI)
        {
            if (!invokeOnlyIfStartedOverGui && startedOverGUI)
                return;

            if (invokeOnlyIfWholeLifecycle && !touchBegan)
                return;

            if (debugLog)
                Debug.Log(gameObject.name + " " + this.GetType().Name + " OnTouchUpdate");

            OnTouchUpdate(screenPos);
        }

        void OnTouchEndEvent(Vector2 screenPos, bool startedOverGUI)
        {
            if (!invokeOnlyIfStartedOverGui && startedOverGUI)
                return;

            if (invokeOnlyIfWholeLifecycle && !touchBegan)
                return;
            
            if (debugLog)
                Debug.Log(gameObject.name + " " + this.GetType().Name + " OnTouchEnd");

            OnTouchEnd(screenPos);

            touchBegan = false;
        }

        void OnEnable()
        {
            ScreenTouchEventBroadcaster.onTouchBegin += OnTouchBeginEvent;
            ScreenTouchEventBroadcaster.onTouchUpdate += OnTouchUpdateEvent;
            ScreenTouchEventBroadcaster.onTouchEnd += OnTouchEndEvent;
        }

        void OnDisable()
        {
            ScreenTouchEventBroadcaster.onTouchBegin -= OnTouchBeginEvent;
            ScreenTouchEventBroadcaster.onTouchUpdate -= OnTouchUpdateEvent;
            ScreenTouchEventBroadcaster.onTouchEnd -= OnTouchEndEvent;
        }
    }
}