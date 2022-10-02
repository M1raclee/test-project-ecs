using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Initialization
{
    public class DoorsInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;

        public DoorsInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var doorsData = _staticData.ForDoors();
            
            for (var i = 0; i < doorsData.TotalCount; i++)
            {
                var button = world.NewEntity();
                
                world.GetPool<DoorTag>().Add(button);
                world.GetPool<Identifier>().Add(button);
                world.GetPool<MovementInput>().Add(button);
                world.GetPool<Location>().Add(button);
                world.GetPool<MovementResult>().Add(button);
                ref var param = ref world.GetPool<MovementParams>().Add(button);
                
                param.Speed = doorsData.MovingSpeed;
                param.Equalizer = 0.001f;
            }
        }
    }
}