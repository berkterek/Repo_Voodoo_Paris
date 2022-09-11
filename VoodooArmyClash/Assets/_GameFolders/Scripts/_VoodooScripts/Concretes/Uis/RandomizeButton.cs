using System.Collections;
using Voodoo.Abstracts.Uis;
using Voodoo.Managers;

namespace Voodoo.Uis
{
    public class RandomizeButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            StartCoroutine(HandleOnButtonClickedAsync());
        }

        IEnumerator HandleOnButtonClickedAsync()
        {
            _button.interactable = false;
            yield return SoldierManager.Instance.ClearAllSoldiersAndCreate();
            _button.interactable = true;
        }
    }
}
