using Voodoo.Abstracts.Uis;
using Voodoo.Managers;

namespace Voodoo.Uis
{
    public class MenuButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadMenu();
        }
    }
}