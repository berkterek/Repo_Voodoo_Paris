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

        [BoxGroup("Test Purpose")]
        [SerializeField]
        bool _isGameStart = false;

        public bool IsTeamALose => _allSoldiers[TeamType.TeamA].TrueForAll(x => x.HealthManager.IsDead);
        public bool IsTeamBLose => _allSoldiers[TeamType.TeamB].TrueForAll(x => x.HealthManager.IsDead);

        void Awake()
        {
            SetSingleton(this);
            _allSoldiers = new Dictionary<TeamType, List<SoldierController>>();
            _allSoldiers[TeamType.TeamA] = new List<SoldierController>();
            _allSoldiers[TeamType.TeamB] = new List<SoldierController>();
        }

        IEnumerator Start()
        {
            yield return CreateBothSideSoldiersAsync();
        }

        public IEnumerator ClearAllSoldiersAndCreate()
        {
            foreach (List<SoldierController> soldierControllers in _allSoldiers.Values)
            {
                int count = soldierControllers.Count;
                for (int i = 0; i < count; i++)
                {
                    var soldier = soldierControllers[0];
                    soldierControllers.Remove(soldierControllers[0]);
                    Destroy(soldier.gameObject);
                    yield return null;
                }
            }

            yield return CreateBothSideSoldiersAsync();
        }

        IEnumerator CreateBothSideSoldiersAsync()
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

        void Update()
        {
            if (!_isGameStart) return;
            
            for (int i = 1; i < _allSoldiers.Count +1; i++)
            {
                int iOpposite = i % 2 == 0 ? 1 : 2; 
                int count = _allSoldiers[(TeamType)i].Count;
                var soldiers = _allSoldiers[(TeamType)i];
                for (int j = 0; j < count; j++)
                {
                    var soldier = soldiers[j];
                    if(soldier.HealthManager.IsDead) continue;

                    if (soldier.Target != null)
                    {
                        if (soldier.Target.HealthManager.IsDead)
                        {
                            soldier.SetTarget(null);
                        }
                        else
                        {
                            continue;
                        }    
                    }

                    int oppositeCount = _allSoldiers[(TeamType)iOpposite].Count;
                    var oppositeSoldiers = _allSoldiers[(TeamType)iOpposite];
                    float nearestDistance = float.MaxValue;
                    int minHealth = int.MaxValue;
                    int oppositeIndex = 0;
                    for (int k = 0; k < oppositeCount; k++)
                    {
                        if(oppositeSoldiers[k].HealthManager.IsDead) continue;

                        if(soldier.ShapeType == ShapeType.Cube)
                        {
                            float currentDistance = Vector3.Distance(soldier.Transform.position, oppositeSoldiers[k].Transform.position);
                            if (currentDistance < nearestDistance)
                            {
                                nearestDistance = currentDistance;
                                oppositeIndex = k;
                            }    
                        }
                        else
                        {
                            if (minHealth > oppositeSoldiers[k].HealthManager.CurrentHealth)
                            {
                                minHealth = oppositeSoldiers[k].HealthManager.CurrentHealth;
                                oppositeIndex = k;
                            }
                        }
                    }
                    
                    soldier.SetTarget(oppositeSoldiers[oppositeIndex]);
                }
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