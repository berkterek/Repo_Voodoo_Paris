using UnityEngine;
using Voodoo.Abstracts.Uis;
using Voodoo.Managers;

namespace Voodoo.Uis
{
    public class BattleButton : BaseButton
    {
        [SerializeField] GameObject _startGameObject;
        
        protected override void HandleOnButtonClicked()
        {
            SoldierManager.Instance.StartBattle();
            _startGameObject.SetActive(false);
        }
    }
}