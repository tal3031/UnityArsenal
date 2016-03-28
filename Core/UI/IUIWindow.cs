using System;

namespace UnityArsenal.Core.UI
{
    public delegate void UIWindowEvent(IUIWindow uiWindow);

    public interface IUIWindow
    {
        event UIWindowEvent WindowShown;
        event UIWindowEvent WindowHidden;

        void Show();
        void Hide();
        void Enable();
        void Disable();
    }
}