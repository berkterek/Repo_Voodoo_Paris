using System;
using System.Collections;
using System.Collections.Generic;
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

        void Awake()
        {
            SetSingleton(this);
        }

        IEnumerator Start()
        {
            yield return CreateSoldierAsync();
        }

        IEnumerator CreateSoldierAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                var soldier = Instantiate(_soldierPrefab);
                soldier.BindTeam(TeamType.TeamA);

                while (soldier.CurrentHealth <= 0 || soldier.CurrentDamage <= 0 || soldier.CurrentAttackRate <= 0f || soldier.CurrentMoveSpeed <= 0f)
                {
                    soldier.BindBasicStats(GetRandomStats<BasicStats>(_basicStatsArray));
                    soldier.BindShapeStats(GetRandomStats<ShapeStats>(_shapeStatsArray));
                    soldier.BindSizeStats(GetRandomStats<SizeStats>(_sizeStatsArray));
                    soldier.BindColorStats(GetRandomStats<ColorStats>(_colorStatsArray));
                    yield return null;    
                }
            }
        }

        T GetRandomStats<T>(T[] stats) where T : class, IStats
        {
            return stats[Random.Range(0, stats.Length)];
        }
    }    
}