namespace Voodoo.Abstracts.Combats
{
    public interface IAttackerDal
    {
        int BasicDamage { get; }
        float AttackRate { get; }
    }
}