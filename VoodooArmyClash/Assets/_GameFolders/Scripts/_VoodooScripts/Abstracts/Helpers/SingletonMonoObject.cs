using UnityEngine;

namespace Voodoo.Abstracts.Helpers
{
    public abstract class SingletonMonoObject<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; protected set; }

        protected abstract void SetSingleton(T instance);
    }
}