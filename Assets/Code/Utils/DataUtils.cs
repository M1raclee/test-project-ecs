using System.Numerics;

namespace Code.Utils
{
    public static class DataUtils
    {
        public static Vector3 ToSystemVector3(this UnityEngine.Vector3 vector) =>
            new(vector.x, vector.y, vector.z);
        
        public static UnityEngine.Vector3 ToUnityVector3(this Vector3 vector) =>
            new(vector.X, vector.Y, vector.Z);
    }
}