using System.Numerics;
using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems.Movement
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movableFilter = world.Filter<MovementResult>().Inc<MovementInput>().Inc<MovementParams>().End();

            var movementResult = world.GetPool<MovementResult>();
            var movementInput = world.GetPool<MovementInput>();
            var movementParams = world.GetPool<MovementParams>();

            foreach (var entity in movableFilter)
            {
                ref var result = ref movementResult.Get(entity);
                ref var entityInput = ref movementInput.Get(entity);
                ref var currentParams = ref movementParams.Get(entity);

                var offset = entityInput.Axis * currentParams.Speed * currentParams.Equalizer;

                result.Offset = offset;
                result.Direction = entityInput.Axis == Vector3.Zero
                    ? Vector3.Zero
                    : Vector3.Normalize(entityInput.Axis);
            }
        }
    }
}