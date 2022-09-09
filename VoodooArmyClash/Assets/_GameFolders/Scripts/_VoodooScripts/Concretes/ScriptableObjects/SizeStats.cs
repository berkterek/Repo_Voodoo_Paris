using UnityEngine;
using Voodoo.Abstracts.ScriptableObjects;

namespace Voodoo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Size Stats", menuName = "Voodoo/Stats/Size Stats")]
    public class SizeStats : ScriptableObject, IStats
    {
        [SerializeField] int _sizeHealth;
        [SerializeField] Vector3 _sizeScale;

        public int SizeHealth => _sizeHealth;
        public Vector3 SizeScale => _sizeScale;
    }
}