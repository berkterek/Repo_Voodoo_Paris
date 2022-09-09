using UnityEngine;
using Voodoo.Enums;

namespace Voodoo.Abstracts.Controllers
{
    public interface ISoldierBodyController : IEntityController
    {
        MeshRenderer MeshRenderer { get; }
        ShapeType ShapeType { get; }
    }
}