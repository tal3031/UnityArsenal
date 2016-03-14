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

        public ILog Logger
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
                Logger = InitLogger();
                OnAwake();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }

            Logger.Log("Unity app awake", LogType.Log);
        }

        private void Start()
        {
            try
            {
                OnStart();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }

            Logger.Log("Unity app start", LogType.Log);
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
                Logger.Log(ex);
            }
        }

        #endregion //Private Methods

        #region Protected Methods

        protected abstract ILog InitLogger();

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
