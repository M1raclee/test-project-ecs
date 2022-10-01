using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems
{
    public class DoorsInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;

        public DoorsInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            for (var i = 0; i < _staticData.ForDoors().TotalCount; i++)
            {
                var button = world.NewEntity();
                world.GetPool<DoorTag>().Add(button);
                world.GetPool<DoorState>().Add(button);
            }
        }
    }
}