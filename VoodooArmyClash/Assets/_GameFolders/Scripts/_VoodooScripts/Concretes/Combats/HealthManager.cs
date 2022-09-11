using Voodoo.Abstracts.Combats;

namespace Voodoo.Combats
{
    public class HealthManager : IHealthService
    {
        readonly IHealthDal _healthDal;

        public bool IsDead => _healthDal.CurrentHealth <= 0;

        public event System.Action OnDead;

        public HealthManager(IHealthDal healthDal)
        {
            _healthDal = healthDal;
        }

        public void DamageProcess(IAttackerService attacker)
        {
            if (IsDead) return;
            
            _healthDal.TakeDamage(attacker.Damage);

            if (IsDead)
            {
                OnDead?.Invoke();
            }
        }
    }
}