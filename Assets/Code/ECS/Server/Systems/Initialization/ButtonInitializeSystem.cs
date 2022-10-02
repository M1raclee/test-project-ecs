using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems
{
    public class ButtonInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;

        public ButtonInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            for (var i = 0; i < _staticData.ForButtons().TotalCount; i++)
            {
                var button = world.NewEntity();
                world.GetPool<ButtonTag>().Add(button);
                world.GetPool<ButtonState>().Add(button);
            }
        }
    }
}