namespace Voodoo.Abstracts.Combats
{
    public interface IHealthDal
    {
        void TakeDamage(int damage);
        int CurrentHealth { get; }
    }
}