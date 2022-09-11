using Voodoo.Abstracts.Uis;
using Voodoo.Managers;

namespace Voodoo.Uis
{
    public class GameButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadGame();
        }
    }
}