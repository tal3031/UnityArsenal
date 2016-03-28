using UnityArsenal.Core.Commands;
using UnityEngine;

namespace UnityArsenal.Core.UI
{
    public abstract class BaseUIWindow : MonoBehaviour, IUIWindow
    {
        #region Fields
        
        private INotifyingCommand _showCommand;
        private INotifyingCommand _hideCommand;

        #endregion

        #region Events

        public event UIWindowEvent WindowShown;
        public event UIWindowEvent WindowHidden;
        
        #endregion

        #region Public Methods

        public abstract void Disable();
        public abstract void Enable();

        public void Show()
        {
            OnShow();

            if (_showCommand == null)
            {
                FireWindowShownEvent();
                return;
            }

            AttachShowCommandEvents();
            _showCommand.Execute();
        }
        
        public void Hide()
        {
            OnHide();

            if (_hideCommand == null)
            {
                FireWindowHiddenEvent();
                return;
            }

            AttachHideCommandEvents();
            _hideCommand.Execute();
        }
        
        #endregion

        #region Protected Methods

        protected void SetShowCommand(INotifyingCommand showCommand)
        {
            _showCommand = showCommand;
        }

        protected void SetHideCommand(INotifyingCommand hideCommand)
        {
            _hideCommand = hideCommand;
        }

        protected virtual void OnShow()
        {

        }

        protected virtual void OnHide()
        {

        }

        #endregion

        #region Private Methods
        
        private void OnDestroy()
        {
            DetachShowCommandEvents();
            DetachHideCommandEvents();
        }

        private void FireWindowShownEvent()
        {
            if (WindowShown != null)
            {
                WindowShown(this);
            }
        }

        private void FireWindowHiddenEvent()
        {
            if (WindowHidden != null)
            {
                WindowHidden(this);
            }
        }
        
        private void AttachShowCommandEvents()
        {
            if (_showCommand != null)
            {
                _showCommand.ExecutionComplete += showCommand_ExecutionComplete;
            }
        }

        private void AttachHideCommandEvents()
        {
            if (_hideCommand != null)
            {
                _hideCommand.ExecutionComplete += hideCommand_ExecutionComplete;
            }
        }
        
        private void DetachShowCommandEvents()
        {
            if (_showCommand != null)
            {
                _showCommand.ExecutionComplete -= showCommand_ExecutionComplete;
            }
        }
        
        private void DetachHideCommandEvents()
        {
            if (_hideCommand != null)
            {
                _hideCommand.ExecutionComplete -= hideCommand_ExecutionComplete;
            }
        }

        private void showCommand_ExecutionComplete(ICommand command)
        {
            DetachShowCommandEvents();
            FireWindowShownEvent();
        }

        private void hideCommand_ExecutionComplete(ICommand command)
        {
            DetachHideCommandEvents();
            FireWindowHiddenEvent();
        }

        #endregion
    }
}