using Code.ECS.Shared.Components;
using Code.Utils;
using Leopotam.EcsLite;
using UnityEngine;
using GameObject = Code.ECS.Client.Components.GameObject;

namespace Code.ECS.Client.Systems.Movement
{
    public class GameObjectMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movementObjectsFilter = world.Filter<GameObject>().Inc<MovementDirection>().End();

            var directions = world.GetPool<MovementDirection>();
            var gameObject = world.GetPool<GameObject>();

            foreach (var entity in movementObjectsFilter)
            {
                ref var movableObject = ref gameObject.Get(entity);
                ref var direction = ref directions.Get(entity);

                movableObject.Transform.position += direction.Offset.ToUnityVector3() * Time.deltaTime;
            }
        }
    }
}