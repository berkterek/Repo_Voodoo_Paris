using Sirenix.OdinInspector;
using UnityEngine;
using Voodoo.Abstracts.Controllers;
using Voodoo.Enums;
using Voodoo.Helpers;
using Voodoo.ScriptableObjects;

namespace Voodoo.Controllers
{
    public class SoldierController : MonoBehaviour, ISoldierController
    {
        [ReadOnly] 
        [SerializeField] TeamType _teamType;
        [ReadOnly]
        [BoxGroup("Current Info")]
        [SerializeField] int _currentHealth;
        [ReadOnly]
        [BoxGroup("Current Info")]
        [SerializeField] float _currentMoveSpeed;
        [ReadOnly]
        [BoxGroup("Current Info")]
        [SerializeField] int currentCurrentDamage;
        [ReadOnly]
        [BoxGroup("Current Info")]
        [SerializeField] float _currentAttackRate;

        [BoxGroup("Game Object Infos")]
        [ReadOnly]
        [SerializeField]
        Transform _transform;
        
        [BoxGroup("Game Object Infos")]
        [SerializeField]
        [ReadOnly]
        SoldierBodyController _soldierBodyController;

        [BoxGroup("Stats")] [SerializeField] [ReadOnly]
        BasicStats _basicStats;
        [BoxGroup("Stats")] [SerializeField] [ReadOnly]
        ShapeStats _shapeStats;
        [BoxGroup("Stats")] [SerializeField] [ReadOnly]
        SizeStats _sizeStats;
        [BoxGroup("Stats")] [SerializeField] [ReadOnly]
        ColorStats _colorStats;

        public TeamType TeamType { get; }
        public int CurrentHealth => _currentHealth;
        public float CurrentMoveSpeed => _currentMoveSpeed;
        public int CurrentDamage => currentCurrentDamage;
        public float CurrentAttackRate => _currentAttackRate;
        public Transform Transform => _transform;

        void Awake()
        {
            this.GetReference(ref _transform);
        }

        void OnValidate()
        {
            this.GetReference(ref _transform);
        }

        public void BindTeam(TeamType teamType)
        {
            _teamType = teamType;
        }

        public void BindBasicStats(BasicStats basicStats)
        {
            _basicStats = basicStats;
            _currentHealth = _basicStats.BasicHealth;
            currentCurrentDamage = _basicStats.BasicDamage;
            _currentAttackRate = _basicStats.BasicAttackRate;
            _currentMoveSpeed = _basicStats.BasicMoveSpeed;
        }

        public void BindShapeStats(ShapeStats shapeStats)
        {
            _shapeStats = shapeStats;
            _soldierBodyController = Instantiate(_shapeStats.ShapePrefab,this._transform);
            currentCurrentDamage += _shapeStats.ShapeDamage;
            _currentHealth += _shapeStats.ShapeHealth;
        }

        public void BindColorStats(ColorStats colorStats)
        {
            _colorStats = colorStats;
            _soldierBodyController.MeshRenderer.material = _colorStats.ColorMaterial;
            
            currentCurrentDamage += _colorStats.ColorDamage;
            _currentHealth += _colorStats.ColorHealth;
            _currentAttackRate += _colorStats.ColorAttackRate;
            _currentMoveSpeed += _colorStats.ColorMoveSpeed;
        }

        public void BindSizeStats(SizeStats sizeStats)
        {
            _sizeStats = sizeStats;
            _soldierBodyController.Transform.localScale = _sizeStats.SizeScale;
            _currentHealth += _sizeStats.SizeHealth;
        }
    }
}