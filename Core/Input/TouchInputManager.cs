using System;
using UnityEngine;

namespace UnityArsenal.Core.Input
{
    public class TouchInputManager : MonoBehaviour, IUnityTouchInputManager
    {
        #region Fields

        private const int _everythingLayer = -1; //"Everything" layer
        private const int defaultTouchIndex = 0;

        private Camera _touchCamera;
        private int _touchLayerMask;

        #endregion

        public event TouchEvent OnTap;
        
        public void SetTouchParameters(Camera touchCamera, int touchLayerMask)
        {
            _touchCamera = touchCamera;
            _touchLayerMask = touchLayerMask;
        }

        #region Private Methods

        private void Awake()
        {
            _touchLayerMask = _everythingLayer;
        }

        private void Update()
        {
            //Default touch
            
        }

        private void handleDefaultTouch()
        {
            var touch = UnityEngine.Input.GetTouch(defaultTouchIndex);

            handleTouch(touch);
        }

        private void handleTouch(Touch touch)
        {
            Debug.Log("Touch phase = " + touch.phase.ToString());

            if (OnTap != null)
            {
                //OnTouch(touch);
            }
        }
        
        #endregion
    }
}
