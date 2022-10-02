using Code.ECS.Shared.Data;

namespace Code.Data
{
    public class ButtonsData : IButtonsData
    {
        public int TotalCount { get; set; }
        public float MovingSpeed { get; } = 1.5f;
    }
}