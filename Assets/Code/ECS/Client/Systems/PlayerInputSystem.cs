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
            var playerInputFilter = world.Filter<PlayerTag>().Inc<MovementInput>().Inc<MovementParams>().End();
            var movementInput = world.GetPool<MovementInput>();
            var movementParams = world.GetPool<MovementParams>();

            foreach (var entity in playerInputFilter)
            {
                ref var playerInput = ref movementInput.Get(entity);
                ref var param = ref movementParams.Get(entity);
                // OFC we need to send player input to server for validation, but we have not server now
                var axis = _inputService.Axis.ToSystemVector3();
                axis.Y = param.Gravity;
                
                playerInput.Axis = axis;
                param.Equalizer = Time.deltaTime;
            }
        }
    }
}