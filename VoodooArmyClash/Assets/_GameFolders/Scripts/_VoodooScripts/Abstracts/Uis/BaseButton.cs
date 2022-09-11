using UnityEngine;
using UnityEngine.UI;
using Voodoo.Helpers;

namespace Voodoo.Abstracts.Uis
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        void Awake()
        {
            this.GetReference(ref _button);
        }

        void OnValidate()
        {
            this.GetReference(ref _button);
        }

        void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        protected abstract void HandleOnButtonClicked();
    }    
}

