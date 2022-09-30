using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class PlayerInitializeSystem : IEcsInitSystem
    {
        private PlayerObject _playerObject;

        public void SetupPlayerObject(PlayerObject playerObject) =>
            _playerObject = playerObject;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var player = world.NewEntity();

            world.GetPool<PlayerTag>().Add(player);
            world.GetPool<MovementInput>().Add(player);
            ref var transformMovement = ref world.GetPool<TransformMovement>().Add(player);

            transformMovement.Target = _playerObject.transform;
        }
    }
}