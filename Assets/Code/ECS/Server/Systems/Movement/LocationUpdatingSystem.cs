using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Movement
{
    public class LocationUpdatingSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movementObjectsFilter = world.Filter<Location>().Inc<MovementDirection>().End();
            
            var movementDirections = world.GetPool<MovementDirection>();
            var locations = world.GetPool<Location>();

            foreach (var entity in movementObjectsFilter)
            {
                ref var direction = ref movementDirections.Get(entity);
                ref var location = ref locations.Get(entity);

                location.Position += direction.Offset;
            }
        }
    }
}