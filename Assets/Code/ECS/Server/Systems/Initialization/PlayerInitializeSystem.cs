using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Services.StaticData;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Initialization
{
    public class PlayerInitializeSystem : IEcsInitSystem
    {
        private readonly IStaticData _staticData;

        public PlayerInitializeSystem(IStaticData staticData) =>
            _staticData = staticData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var player = world.NewEntity();

            world.GetPool<PlayerTag>().Add(player);
            world.GetPool<MovementInput>().Add(player);
            world.GetPool<MovementDirection>().Add(player);
            world.GetPool<ButtonsInteractor>().Add(player);
            ref var movementParams = ref world.GetPool<MovementParams>().Add(player);

            movementParams.Speed = _staticData.ForPlayer().MovementSpeed;
            movementParams.Gravity = _staticData.ForPlayer().Gravity;
            movementParams.Equalizer = 1;
        }
    }
}