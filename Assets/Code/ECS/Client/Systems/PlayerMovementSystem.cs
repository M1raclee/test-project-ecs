using Code.ECS.Server.Tags;
using Code.ECS.Shared.Components;
using Code.Services.InputService;
using Code.Utils;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly IInputService _inputService;

        public PlayerMovementSystem(IInputService inputService) => 
            _inputService = inputService;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerInputFilter = world.Filter<PlayerTag>().Inc<MovementInput>().End();
            var movementInput = world.GetPool<MovementInput>();

            foreach (var entity in playerInputFilter)
            {
                ref var playerInput = ref movementInput.Get(entity);
                // OFC we need to send player input to server for validation, but we have not server now
                playerInput.Axis = _inputService.Axis.ToSystemVector3();
            }
        }
    }
}