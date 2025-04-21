using UnityEngine;

namespace Utils
{
    [DefaultExecutionOrder(-100)]
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            Instance = this as T;
        }
    }
}
