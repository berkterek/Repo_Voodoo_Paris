using UnityEngine;
using Voodoo.Abstracts.Combats;

namespace Voodoo.Combats
{
    public class AttackerManager : IAttackerService
    {
        readonly IAttackerDal _attackerDal;

        float _currentAttackTime = 0f;

        public int Damage => _attackerDal.BasicDamage;
        public event System.Action OnTargetDestroyed;

        public AttackerManager(IAttackerDal attackerDal)
        {
            _attackerDal = attackerDal;
        }

        public void AttackProcess(IHealthService healthService)
        {
            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _attackerDal.AttackRate)
            {
                _currentAttackTime = 0f;

                if (healthService.IsDead)
                {
                    OnTargetDestroyed?.Invoke();
                    return;
                }
                healthService.DamageProcess(this);
            }
        }
    }
}