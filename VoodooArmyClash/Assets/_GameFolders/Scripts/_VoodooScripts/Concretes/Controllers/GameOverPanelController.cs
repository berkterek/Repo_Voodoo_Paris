using System.Collections;
using TMPro;
using UnityEngine;
using Voodoo.Managers;

namespace Voodoo.Controllers
{
    public class GameOverPanelController : MonoBehaviour
    {
        [SerializeField] GameObject _background;
        [SerializeField] TMP_Text _winMessageText;
        [SerializeField] float _delayTime = 3f;

        void OnEnable()
        {
            GameManager.Instance.OnGameOvered += HandleOnGameOvered;
        }

        void OnDisable()
        {
            GameManager.Instance.OnGameOvered -= HandleOnGameOvered;
        }
        
        void HandleOnGameOvered(string value)
        {
            StartCoroutine(HandleOnGameOveredAsync(value));
        }

        IEnumerator HandleOnGameOveredAsync(string value)
        {
            yield return new WaitForSeconds(_delayTime);
            _winMessageText.SetText(value);
            _background.SetActive(true);
        }
    }    
}