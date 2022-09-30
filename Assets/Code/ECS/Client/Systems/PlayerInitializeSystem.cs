using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.ECS.Client.Systems
{
    public class PlayerInitializeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly PlayerObject _playerObject;
        
        public PlayerInitializeSystem(PlayerObject playerObject) =>
            _playerObject = playerObject;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var player = world.NewEntity();

            world.GetPool<PlayerTag>().Add(player);
            ref var movement = ref world.GetPool<TransformMovement>().Add(player);

            movement.Target = _playerObject.transform;
        }

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerTag>().Inc<TransformMovement>().End();

            foreach (var entity in filter)
            {
                Debug.Log($"Found player entity: {entity}");
            }
        }
    }
}