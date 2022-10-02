using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Movement
{
    public class LocationUpdatingSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movementObjectsFilter = world.Filter<Location>().Inc<MovementResult>().End();
            
            var movementResults = world.GetPool<MovementResult>();
            var locations = world.GetPool<Location>();

            foreach (var entity in movementObjectsFilter)
            {
                ref var result = ref movementResults.Get(entity);
                ref var location = ref locations.Get(entity);

                location.Position += result.Offset;
            }
        }
    }
}