using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{

    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T instance;

        private void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            else
            {
                instance = this as T;
                DontDestroyOnLoad(this);
            }
        }
    } 
}

