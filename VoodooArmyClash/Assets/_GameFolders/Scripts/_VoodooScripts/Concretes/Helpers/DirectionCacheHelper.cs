using UnityEngine;

namespace Voodoo.Helpers
{
    public static class DirectionCacheHelper
    {
        public static Vector3 Zero { get; }
        public static Vector3 Left { get; }
        public static Vector3 Right { get; }
        public static Vector3 Up { get; }
        public static Vector3 Down { get; }
        public static Quaternion Identity { get; }
        
        static DirectionCacheHelper()
        {
            Zero = Vector3.zero;
            Left = Vector3.left;
            Right = Vector3.right;
            Up = Vector3.up;
            Down = Vector3.down;
            Identity = Quaternion.identity;
        }
    }
}