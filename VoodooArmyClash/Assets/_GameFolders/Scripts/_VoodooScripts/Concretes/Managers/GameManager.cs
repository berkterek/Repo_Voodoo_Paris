using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Voodoo.Abstracts.Helpers;

namespace Voodoo.Managers
{
    public class GameManager : SingletonDontDestroyObject<GameManager>
    {
        public event System.Action<string> OnGameOvered; 

        void Awake()
        {
            Application.targetFrameRate = 60;
            SetSingleton(this);
        }

        public void CheckHowIsWin()
        {
            string winMessage = string.Empty;
            if (SoldierManager.Instance.IsTeamALose)
            {
                winMessage = "Team B Wins";
                Debug.Log(winMessage);
                OnGameOvered?.Invoke(winMessage);
            }
            else if (SoldierManager.Instance.IsTeamBLose)
            {
                winMessage = "Team A Wins";
                Debug.Log(winMessage);
                OnGameOvered?.Invoke(winMessage);
            }
        }

        public void LoadMenu()
        {
            StartCoroutine(LoadSceneAsync("Menu"));
        }

        public void LoadGame()
        {
            StartCoroutine(LoadSceneAsync("Game"));
        }

        IEnumerator LoadSceneAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }
    }    
}