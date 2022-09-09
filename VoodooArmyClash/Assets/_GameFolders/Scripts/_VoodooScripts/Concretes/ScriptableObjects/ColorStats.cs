using UnityEngine;
using Voodoo.Abstracts.ScriptableObjects;

namespace Voodoo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Color Stats", menuName = "Voodoo/Stats/Color Stats")]
    public class ColorStats : ScriptableObject, IStats
    {
        [SerializeField] int _colorHealth = 100;
        [SerializeField] float _colorMoveSpeed = 10f;
        [SerializeField] int _colorDamage = 10;
        [SerializeField] float _colorAttackRate = 1f;
        [SerializeField] Material _colorMaterial;
        
        public int ColorHealth => _colorHealth;
        public float ColorMoveSpeed => _colorMoveSpeed;
        public int ColorDamage => _colorDamage;
        public float ColorAttackRate => _colorAttackRate;
        public Material ColorMaterial => _colorMaterial;
    }
}