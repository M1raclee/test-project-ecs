using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Code.ECS.Shared.Components;
using Code.Utils;
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
            world.GetPool<MovementVelocity>().Add(player);
            ref var movementParams = ref world.GetPool<MovementParams>().Add(player);
            ref var characterMovement = ref world.GetPool<CharacterMovement>().Add(player);

            characterMovement.Target = _playerObject.Character;
            movementParams.Speed = 8f;
            movementParams.Gravity = -20f;
        }
    }
}