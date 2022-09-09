using UnityEngine;

namespace Voodoo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Basic Stats",menuName = "Voodoo/Stats/Basic Stats")]
    public class BasicStats : ScriptableObject
    {
        [SerializeField] int _basicHealth = 100;
        [SerializeField] float _basicMoveSpeed = 10f;
        [SerializeField] int _basicDamage = 10;
        [SerializeField] float _basicAttackRate = 1f;

        public int BasicHealth => _basicHealth;
        public float BasicMoveSpeed => _basicMoveSpeed;
        public int BasicDamage => _basicDamage;
        public float BasicAttackRate => _basicAttackRate;
    }
}