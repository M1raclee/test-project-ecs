using Code.ECS.Server.Tags;
using Code.ECS.Shared.Components;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems
{
    public class GameplayButtonInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;

        public GameplayButtonInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            for (var i = 0; i < _staticData.ForButtons().TotalCount; i++)
            {
                var button = world.NewEntity();
                world.GetPool<GameplayButtonTag>().Add(button);
                world.GetPool<GameplayButtonState>().Add(button);
            }
        }
    }
}