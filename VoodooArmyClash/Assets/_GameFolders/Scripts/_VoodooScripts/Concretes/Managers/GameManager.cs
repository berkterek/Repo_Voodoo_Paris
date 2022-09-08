using UnityEngine;

namespace Voodoo.Managers
{
    public class GameManager : MonoBehaviour
    {
        void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }    
}

