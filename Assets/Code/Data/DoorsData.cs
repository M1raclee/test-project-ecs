using Code.ECS.Shared.Data;

namespace Code.Data
{
    public class DoorsData : IDoorsData
    {
        public int TotalCount { get; set; }
        public float MovingSpeed { get; } = 1f;
    }
}