using UnityEngine;

namespace UnityArsenal.Core.Input
{
    public delegate void TouchEvent(int touchIndex, TouchPhase touchPhase, TouchType touchType, GameObject touchedObject);

    public interface IUnityTouchInputManager
    {
        event TouchEvent OnTap;
        void SetTouchParameters(Camera touchCamera, int touchLayerMask);
    }
}
