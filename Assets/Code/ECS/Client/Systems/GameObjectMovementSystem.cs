using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.Utils;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class GameObjectMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var locationFilter = world.Filter<Location>().Inc<GameObjectMovement>().End();
            
            var location = world.GetPool<Location>();
            var gameObject = world.GetPool<GameObjectMovement>();

            foreach (var entity in locationFilter)
            {
                ref var movableObject = ref gameObject.Get(entity);
                ref var newLocation = ref location.Get(entity);

                movableObject.Target.position = newLocation.Position.ToUnityVector3();
            }
        }
    }
}