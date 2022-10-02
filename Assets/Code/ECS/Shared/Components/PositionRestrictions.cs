using System.Numerics;

namespace Code.ECS.Shared.Components
{
    public struct PositionRestrictions
    {
        public Vector3 MinPosition;
        public Vector3 MaxPosition;
    }
}