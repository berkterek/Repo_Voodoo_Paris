using Voodoo.Abstracts.Combats;

namespace Voodoo.Combats
{
    public class BasicHealthDal : IHealthDal
    {
        readonly int _maxHealth;

        int _currentHealth;

        public int CurrentHealth => _currentHealth;

        public BasicHealthDal(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }
    }
}