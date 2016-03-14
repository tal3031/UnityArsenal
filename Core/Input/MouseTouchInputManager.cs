using System;
using UnityEngine;

namespace UnityArsenal.Core.Input
{
    public class MouseTouchInputManager : MonoBehaviour, IUnityTouchInputManager
    {
        #region Fields

        private Camera _touchCamera;
        [SerializeField]
        private LayerMask _touchLayerMask;
        
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
            //_touchLayerMask = int.MaxValue;
        }

        private void Update()
        {
            Debug.Log(_touchLayerMask.value);

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                handleTap(UnityEngine.Input.mousePosition);
            }
        }

        private void handleTap(Vector3 mousePosition)
        {
            const float rayDistance = 5f;

            GameObject clickedObject = null;

            if (_touchCamera != null)
            {
                var mousePositionRay = _touchCamera.ScreenPointToRay(mousePosition);
                RaycastHit raycastHitInfo;
                var raycastHit = Physics.Raycast(mousePositionRay, out raycastHitInfo, rayDistance);
            }

            if (OnTap != null)
            {
                OnTap(0, TouchPhase.Ended, TouchType.Direct, clickedObject);
            }
        }

        #endregion
    }
}
