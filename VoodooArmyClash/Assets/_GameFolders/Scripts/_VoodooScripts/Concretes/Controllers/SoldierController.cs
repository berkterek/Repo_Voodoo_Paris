using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using Voodoo.Abstracts.Combats;
using Voodoo.Abstracts.Controllers;
using Voodoo.Combats;
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
        [SerializeField] int _currentDamage;
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

        [BoxGroup("Game Object Infos")] [SerializeField] [ReadOnly]
        NavMeshAgent _navMeshAgent;

        [BoxGroup("Game Object Infos")] [SerializeField]
        SoldierController _target;

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
        public int CurrentDamage => _currentDamage;
        public float CurrentAttackRate => _currentAttackRate;
        public IHealthService HealthManager { get; private set; }
        public IAttackerService AttackManager { get; private set; }
        public Transform Transform => _transform;


        void Awake()
        {
            this.GetReference(ref _transform);
            this.GetReference(ref _navMeshAgent);
        }

        void OnValidate()
        {
            this.GetReference(ref _transform);
            this.GetReference(ref _navMeshAgent);
        }

        void Update()
        {
            if (_target == null) return;

            //TODO refactor Movement code 
            if (Vector3.Distance(_target.Transform.position, Transform.position) < 2f)
            {
                if (_navMeshAgent.isStopped) return;

                _navMeshAgent.isStopped = true;
            }
            else
            {
                _navMeshAgent.SetDestination(_target.Transform.position);
            }
        }

        public void BindTeam(TeamType teamType)
        {
            _teamType = teamType;
        }

        public void BindBasicStats(BasicStats basicStats)
        {
            _basicStats = basicStats;
            _currentHealth = _basicStats.BasicHealth;
            _currentDamage = _basicStats.BasicDamage;
            _currentAttackRate = _basicStats.BasicAttackRate;
            _currentMoveSpeed = _basicStats.BasicMoveSpeed;
        }

        public void BindShapeStats(ShapeStats shapeStats)
        {
            _shapeStats = shapeStats;
            _soldierBodyController = Instantiate(_shapeStats.ShapePrefab,this._transform);
            _soldierBodyController.Transform.localPosition = DirectionCacheHelper.Up;
            _currentDamage += _shapeStats.ShapeDamage;
            _currentHealth += _shapeStats.ShapeHealth;
        }

        public void BindColorStats(ColorStats colorStats)
        {
            _colorStats = colorStats;
            _soldierBodyController.MeshRenderer.material = _colorStats.ColorMaterial;
            
            _currentDamage += _colorStats.ColorDamage;
            _currentHealth += _colorStats.ColorHealth;
            _currentAttackRate += _colorStats.ColorAttackRate;
            _currentMoveSpeed += _colorStats.ColorMoveSpeed;

            HealthManager = new HealthManager(new BasicHealthDal(_currentHealth));
            AttackManager = new AttackerManager(new BasicAttackerDal(_currentDamage, _currentAttackRate));
            _navMeshAgent.speed = _currentMoveSpeed;
        }

        public void BindSizeStats(SizeStats sizeStats)
        {
            _sizeStats = sizeStats;
            _soldierBodyController.Transform.localScale = _sizeStats.SizeScale;
            _currentHealth += _sizeStats.SizeHealth;
        }

        public void SetTarget(SoldierController target)
        {
            _target = target;
        }
    }
}