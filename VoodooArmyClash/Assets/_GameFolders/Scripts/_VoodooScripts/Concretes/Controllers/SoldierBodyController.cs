using UnityEngine;
using Voodoo.Abstracts.Controllers;
using Voodoo.Enums;
using Voodoo.Helpers;

namespace Voodoo.Controllers
{
    public class SoldierBodyController : MonoBehaviour, ISoldierBodyController
    {
        [SerializeField] Transform _transform;
        [SerializeField] MeshRenderer _meshRenderer;
        [SerializeField] ShapeType _shapeType;

        public Transform Transform => _transform;
        public MeshRenderer MeshRenderer => _meshRenderer;
        public ShapeType ShapeType => _shapeType;

        void Awake()
        {
            this.GetReference(ref _transform);
            this.GetReference(ref _meshRenderer);
        }

        void OnValidate()
        {
            this.GetReference(ref _transform);
            this.GetReference(ref _meshRenderer);
        }
    }
}