using UnityEngine;

namespace Voodoo.Abstracts.Helpers
{
    public abstract class SingletonDontDestroyObject<T> : SingletonMonoObject<T> where T : Component
    {
        protected override void SetSingleton(T instance)
        {
            if (Instance == null)
            {
                instance.transform.parent = null;
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}