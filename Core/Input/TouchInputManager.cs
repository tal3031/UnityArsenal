using UnityEngine;

namespace UnityArsenal.Core.Input
{
    public class TouchInputManager : MonoBehaviour, IUnityTouchInputManager
    {
        #region Events

        public event TouchEvent OnTap;

        #endregion

        #region Fields

        private const int _everythingLayer = -1; //"Everything" layer
        private const int defaultTouchIndex = 0;

        private Camera _touchCamera;
        private int _touchLayerMask;

        #endregion

        #region Props

        public bool IsEnabled
        {
            get;
            private set;
        }

        #endregion

        public void SetTouchParameters(Camera touchCamera, int touchLayerMask)
        {
            _touchCamera = touchCamera;
            _touchLayerMask = touchLayerMask;
        }

        public void Enable()
        {
            if (IsEnabled)
            {
                return;
            }

            IsEnabled = true;
        }

        public void Disable()
        {
            if (!IsEnabled)
            {
                return;
            }

            IsEnabled = false;
        }

        #region Private Methods

        private void Awake()
        {
            _touchLayerMask = _everythingLayer;
        }

        private void Update()
        {
            if (!IsEnabled)
            {
                return;
            }

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
