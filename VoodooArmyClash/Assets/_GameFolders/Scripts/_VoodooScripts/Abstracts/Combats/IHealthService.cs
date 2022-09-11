namespace Voodoo.Abstracts.Combats
{
    public interface IHealthService
    {
        bool IsDead { get; }
        int CurrentHealth { get; }
        void DamageProcess(IAttackerService attacker);
        event System.Action OnDead;
    }
}