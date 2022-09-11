using UnityEngine;

namespace Voodoo.Abstracts.Movements
{
    public interface IMoverDal
    {
        bool IsStop { get; }
        void SetDestination(Vector3 destination);
        void FixedTick();
        void Stop();
    }
}