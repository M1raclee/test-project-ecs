using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.Utils;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems.Movement
{
    public class LocationUpdatingSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var gameObjectsFilter = world.Filter<Location>().Inc<GameObject>().End();
            
            var gameObjects = world.GetPool<GameObject>();
            var locations = world.GetPool<Location>();

            foreach (var entity in gameObjectsFilter)
            {
                ref var gameObject = ref gameObjects.Get(entity);
                ref var location = ref locations.Get(entity);

                location.Position = gameObject.Transform.position.ToSystemVector3();
            }
        }
    }
}