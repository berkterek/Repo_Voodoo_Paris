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

        void BindTeam(TeamType teamType);
        void BindBasicStats(BasicStats basicStats);
        void BindShapeStats(ShapeStats shapeStats);
        void BindColorStats(ColorStats colorStats);
        void BindSizeStats(SizeStats sizeStats);
    }
}