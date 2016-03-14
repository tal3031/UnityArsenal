using System;
using UnityEngine;

namespace UnityArsenal.Core.Input
{
    public class TouchInputManager : MonoBehaviour, IUnityTouchInputManager
    {
        #region Fields

        private Camera _touchCamera;

        #endregion

        public event TouchEvent OnTap;
        
        public void SetTouchParameters(Camera touchCamera, int touchLayerMask)
        {
            _touchCamera = touchCamera;
        }

        #region Private Methods

        private void Update()
        {
            //Default touch
            
        }

        private void handleDefaultTouch()
        {
            const int defaultTouchIndex = 0;

            var touch = UnityEngine.Input.GetTouch(0);

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
