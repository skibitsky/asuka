using UnityEngine;

namespace Skibitsky.Asuka
{
    public static class MathfExtensions
    {
        public static Vector3 Clamp(this Vector3 source, Vector3 min, Vector3 max)
        {
            source.Set(Mathf.Clamp(source.x, min.x, max.x), 
                Mathf.Clamp(source.y, min.y, max.y),
                Mathf.Clamp(source.z, min.z, max.z));
            return source;
        }

        public static Vector3 Clamp(this Vector3 source, float min, float max)
        {
            source.Set(Mathf.Clamp(source.x, min, max), 
                Mathf.Clamp(source.y, min, max),
                Mathf.Clamp(source.z, min, max));
            return source;
        }
    }
}