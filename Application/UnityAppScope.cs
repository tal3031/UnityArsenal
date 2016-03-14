using UnityEngine;
using System;
using UnityArsenal.Core.Log;

namespace UnityArsenal.Application
{
    public abstract class UnityAppScope : MonoBehaviour
    {
        #region Props

        public static UnityAppScope Current
        {
            get;
            private set;
        }

        public LogManager LogManager
        {
            get;
            private set;
        }

        #endregion //Props

        #region Private Methods

        private void Awake()
        {
            if (Current != null)
            {
                Destroy(this);
                return;
            }

            Current = this;

            try
            {
                LogManager = InitLogManager();
                OnAwake();
            }
            catch (Exception ex)
            {
                LogManager.Logger.Log(ex);
            }

            LogManager.Logger.Log("Unity app awake", LogType.Log);
        }

        private void Start()
        {
            try
            {
                OnStart();
            }
            catch (Exception ex)
            {
                LogManager.Logger.Log(ex);
            }

            LogManager.Logger.Log("Unity app start", LogType.Log);
        }

        private void OnDestroy()
        {
            if (Current != this)
            {
                return;
            }

            Current = null;

            try
            {
                OnAppContextDestroy();
            }
            catch (Exception ex)
            {
                LogManager.Logger.Log(ex);
            }
        }

        #endregion //Private Methods

        #region Protected Methods

        protected abstract LogManager InitLogManager();

        protected virtual void OnAwake()
        {

        }

        protected virtual void OnStart()
        {

        }

        protected virtual void OnAppContextDestroy()
        {

        }

        #endregion //Protected Methods
    }
}
