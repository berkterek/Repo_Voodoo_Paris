using UnityEngine;
using Voodoo.Abstracts.ScriptableObjects;
using Voodoo.Controllers;

namespace Voodoo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Shape Stats", menuName = "Voodoo/Stats/Shape Stats")]
    public class ShapeStats : ScriptableObject, IStats
    {
        [SerializeField] int _shapeHealth = 0;
        [SerializeField] int _shapeDamage = 0;
        [SerializeField] SoldierBodyController _shapePrefab;

        public int ShapeHealth => _shapeHealth;
        public int ShapeDamage => _shapeDamage;
        public SoldierBodyController ShapePrefab => _shapePrefab;
    }
}