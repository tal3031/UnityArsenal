using UnityEngine;

namespace UnityArsenal.Core.Input
{
    public class MouseTouchInputManager : MonoBehaviour, IUnityTouchInputManager
    {
        #region Events

        public event TouchEvent OnTap;

        #endregion

        #region Fields

        private const int _everythingLayer = -1; //"Everything" layer

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

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                handleTap(UnityEngine.Input.mousePosition);
            }
        }

        private void handleTap(Vector3 mousePosition)
        {
            const float rayDistance = 10f;

            GameObject tappedObject = null;

            if (_touchCamera != null)
            {
                var mousePositionRay = _touchCamera.ScreenPointToRay(mousePosition);
                RaycastHit raycastHitInfo;
                var raycastHit = Physics.Raycast(mousePositionRay, out raycastHitInfo, rayDistance, _touchLayerMask, QueryTriggerInteraction.Collide);

                if (raycastHit)
                {
                    tappedObject = raycastHitInfo.collider.gameObject;
                }
            }

            if (OnTap != null)
            {
                OnTap(0, TouchPhase.Ended, TouchType.Direct, tappedObject);
            }
        }
        
        #endregion
    }
}
