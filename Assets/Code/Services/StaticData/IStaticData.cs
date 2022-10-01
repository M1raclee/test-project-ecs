using Code.ECS.Shared.Data;

namespace Code.Services.StaticData
{
    public interface IStaticData
    {
        IPlayerData ForPlayer();
        IButtonsData ForButtons();
        IDoorsData ForDoors();
    }
}