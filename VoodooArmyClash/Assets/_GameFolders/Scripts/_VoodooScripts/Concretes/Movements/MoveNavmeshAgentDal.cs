using UnityEngine;
using UnityEngine.AI;
using Voodoo.Abstracts.Movements;

namespace Voodoo.Movements
{
    public class MoveNavmeshAgentDal : IMoverDal
    {
        readonly NavMeshAgent _navMeshAgent;

        Vector3 _destination;

        public bool IsStop => _navMeshAgent.isStopped;
        
        public MoveNavmeshAgentDal(NavMeshAgent navMeshAgent)
        {
            _navMeshAgent = navMeshAgent;
        }

        public void SetDestination(Vector3 destination)
        {
            _navMeshAgent.isStopped = false;
            _destination = destination;
        }

        public void FixedTick()
        {
            _navMeshAgent.SetDestination(_destination);
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}