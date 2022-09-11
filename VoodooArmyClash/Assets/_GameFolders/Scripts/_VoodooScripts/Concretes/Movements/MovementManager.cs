using UnityEngine;
using Voodoo.Abstracts.Controllers;
using Voodoo.Abstracts.Movements;

namespace Voodoo.Movements
{
    public class MovementManager : IMovementService
    {
        readonly IMoverDal _moverDal;
        readonly ISoldierController _soldier;
        
        public MovementManager(ISoldierController soldier,IMoverDal moverDal)
        {
            _moverDal = moverDal;
            _soldier = soldier;
        }

        public void Tick()
        {
            var target = _soldier.Target;
            if (Vector3.Distance(target.Transform.position, _soldier.Transform.position) < 2f)
            {
                _soldier.AttackManager.AttackProcess(target.HealthManager);
                if (_moverDal.IsStop) return;

                _moverDal.Stop();
            }
            else
            {
                _moverDal.SetDestination(_soldier.Target.Transform.position);
            }
        }

        public void FixedTick()
        {
            _moverDal.FixedTick();
        }
    }
}

