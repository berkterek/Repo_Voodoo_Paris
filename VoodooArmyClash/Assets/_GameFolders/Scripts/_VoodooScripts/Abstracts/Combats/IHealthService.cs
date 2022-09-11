namespace Voodoo.Abstracts.Combats
{
    public interface IHealthService
    {
        bool IsDead { get; }
        void DamageProcess(IAttackerService attacker);
        event System.Action OnDead;
    }
}