namespace Voodoo.Abstracts.Combats
{
    public interface IAttackerService
    {
        int Damage { get; }
        event System.Action TargetDestroyed;
    }
}