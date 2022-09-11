using Voodoo.Abstracts.Combats;

namespace Voodoo.Combats
{
    public class BasicAttackerDal : IAttackerDal
    {
        public int BasicDamage { get; }
        public float AttackRate { get; }

        public BasicAttackerDal(int damage, float attackRate)
        {
            BasicDamage = damage;
            AttackRate = attackRate;
        }
    }
}