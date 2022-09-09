using UnityEngine;
using Voodoo.Controllers;
using Voodoo.Enums;

namespace Voodoo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Shape Stats", menuName = "Voodoo/Stats/Shape Stats")]
    public class ShapeStats : ScriptableObject
    {
        [SerializeField] int _shapeHealth = 0;
        [SerializeField] int _shapeDamage = 0;
        [SerializeField] SoldierBodyController _shapePrefab;

        public int ShapeHealth => _shapeHealth;
        public int ShapeDamage => _shapeDamage;
        public SoldierBodyController ShapePrefab => _shapePrefab;
    }
}