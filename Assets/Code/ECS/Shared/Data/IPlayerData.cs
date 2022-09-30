namespace Code.ECS.Shared.Data
{
    public interface IPlayerData
    {
        float MovementSpeed { get; }
        float Gravity { get; }
        float MovementThreshold { get; }
    }
}