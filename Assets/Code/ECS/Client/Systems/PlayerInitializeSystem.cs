using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Code.ECS.Shared.Components;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class PlayerInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;
        private PlayerObject _playerObject;

        public PlayerInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

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
            movementParams.Speed = _staticData.ForPlayer().MovementSpeed;
            movementParams.Gravity = _staticData.ForPlayer().Gravity;
        }
    }
}