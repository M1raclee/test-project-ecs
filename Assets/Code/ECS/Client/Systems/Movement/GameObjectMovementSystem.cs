using Code.ECS.Shared.Components;
using Code.Utils;
using Leopotam.EcsLite;
using GameObject = Code.ECS.Client.Components.GameObject;

namespace Code.ECS.Client.Systems.Movement
{
    public class GameObjectMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movementObjectsFilter = world.Filter<GameObject>().Inc<Location>().End();

            var locations = world.GetPool<Location>();
            var gameObject = world.GetPool<GameObject>();

            foreach (var entity in movementObjectsFilter)
            {
                ref var movableObject = ref gameObject.Get(entity);
                ref var location = ref locations.Get(entity);

                movableObject.Transform.position = location.Position.ToUnityVector3();
            }
        }
    }
}