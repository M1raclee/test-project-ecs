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
            ref var multiplier = ref world.GetPool<MovementMultiplier>().Add(player);
            ref var location = ref world.GetPool<Location>().Add(player);
            ref var transformMovement = ref world.GetPool<GameObjectMovement>().Add(player);

            transformMovement.Target = _playerObject.transform;
            location.Position = _playerObject.transform.position.ToSystemVector3();
            location.Rotation = _playerObject.transform.eulerAngles.ToSystemVector3();
            multiplier.Multiplier = 0.015f;
        }
    }
}