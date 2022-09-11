namespace Voodoo.Abstracts.Movements
{
    public interface IMovementService
    {
        void Tick();
        void FixedTick();
    }
}