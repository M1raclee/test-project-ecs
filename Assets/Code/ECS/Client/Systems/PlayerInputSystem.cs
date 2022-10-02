using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Services.InputService;
using Code.Utils;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.ECS.Client.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly IInputService _inputService;

        public PlayerInputSystem(IInputService inputService) => 
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
                playerInput.Axis = _inputService.Axis.ToSystemVector3() * Time.deltaTime;
            }
        }
    }
}