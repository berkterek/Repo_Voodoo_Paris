using Voodoo.Abstracts.Combats;
using Voodoo.Abstracts.Movements;
using Voodoo.Controllers;
using Voodoo.Enums;
using Voodoo.ScriptableObjects;

namespace Voodoo.Abstracts.Controllers
{
    public interface ISoldierController : IEntityController
    {
        TeamType TeamType { get; }
        int CurrentHealth { get; }
        float CurrentMoveSpeed { get; }
        int CurrentDamage { get; }
        float CurrentAttackRate { get; }
        IHealthService HealthManager { get; }
        IAttackerService  AttackManager { get; }
        IMovementService MoveManager { get; }
        SoldierController Target { get; }
        void BindTeam(TeamType teamType);
        void BindBasicStats(BasicStats basicStats);
        void BindShapeStats(ShapeStats shapeStats);
        void BindColorStats(ColorStats colorStats);
        void BindSizeStats(SizeStats sizeStats);
    }
}