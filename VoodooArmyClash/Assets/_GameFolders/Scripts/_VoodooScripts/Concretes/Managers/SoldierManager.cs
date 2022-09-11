using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Voodoo.Abstracts.Helpers;
using Voodoo.Abstracts.ScriptableObjects;
using Voodoo.Controllers;
using Voodoo.Enums;
using Voodoo.ScriptableObjects;
using Random = UnityEngine.Random;

namespace Voodoo.Managers
{
    public class SoldierManager : SingletonDestroyObject<SoldierManager>
    {
        [BoxGroup("Stats")] [SerializeField]
        BasicStats[] _basicStatsArray;
        [BoxGroup("Stats")] [SerializeField]
        ShapeStats[] _shapeStatsArray;
        [BoxGroup("Stats")] [SerializeField]
        SizeStats[] _sizeStatsArray;
        [BoxGroup("Stats")] [SerializeField]
        ColorStats[] _colorStatsArray;
        [BoxGroup("Soldiers")]
        [Required]
        [SerializeField] SoldierController _soldierPrefab;
        
        [BoxGroup("Soldiers")]
        [Required]
        [SerializeField]
        GameObject _soldierParentA;
        
        [BoxGroup("Soldiers")]
        [Required]
        [SerializeField]
        GameObject _soldierParentB;
        
        [BoxGroup("Positions")]
        [SerializeField] SoldierPositionInspector[] _soldierPositions;

        [ShowInInspector]
        [ReadOnly]
        Dictionary<TeamType, List<SoldierController>> _allSoldiers;

        void Awake()
        {
            SetSingleton(this);
            _allSoldiers = new Dictionary<TeamType, List<SoldierController>>();
            _allSoldiers[TeamType.TeamA] = new List<SoldierController>();
            _allSoldiers[TeamType.TeamB] = new List<SoldierController>();
        }

        IEnumerator Start()
        {
            yield return CreateSoldierAsync(TeamType.TeamA,_soldierParentA);
            yield return CreateSoldierAsync(TeamType.TeamB,_soldierParentB);
        }
        
        IEnumerator CreateSoldierAsync(TeamType teamType, GameObject soldierParent)
        {
            Transform[] transforms = _soldierPositions.FirstOrDefault(x => x.TeamType == teamType).Transforms;
            for (int i = 0; i < 10; i++)
            {
                var soldier = Instantiate(_soldierPrefab,transforms[i].position,transforms[i].localRotation);
                soldier.Transform.SetParent(soldierParent.transform);
                soldier.BindTeam(teamType);

                while (soldier.CurrentHealth <= 0 || soldier.CurrentDamage <= 0 || soldier.CurrentAttackRate <= 0f || soldier.CurrentMoveSpeed <= 0f)
                {
                    soldier.BindBasicStats(GetRandomStats<BasicStats>(_basicStatsArray));
                    soldier.BindShapeStats(GetRandomStats<ShapeStats>(_shapeStatsArray));
                    soldier.BindSizeStats(GetRandomStats<SizeStats>(_sizeStatsArray));
                    soldier.BindColorStats(GetRandomStats<ColorStats>(_colorStatsArray));
                    yield return null;    
                }
                
                _allSoldiers[teamType].Add(soldier);
            }   
        }

        T GetRandomStats<T>(T[] stats) where T : class, IStats
        {
            return stats[Random.Range(0, stats.Length)];
        }
    }

    [System.Serializable]
    public struct SoldierPositionInspector
    {
        [SerializeField] Transform[] _transforms;
        [SerializeField] TeamType _teamType;

        public TeamType TeamType => _teamType;
        public Transform[] Transforms => _transforms;
    }
}