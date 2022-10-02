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
            var movableFilter = world.Filter<MovementDirection>().Inc<MovementInput>().Inc<MovementParams>().End();

            var movementDirection = world.GetPool<MovementDirection>();
            var movementInput = world.GetPool<MovementInput>();
            var movementParams = world.GetPool<MovementParams>();

            foreach (var entity in movableFilter)
            {
                ref var direction = ref movementDirection.Get(entity);
                ref var entityInput = ref movementInput.Get(entity);
                ref var currentParams = ref movementParams.Get(entity);

                var offset = entityInput.Axis * currentParams.Speed * currentParams.Equalizer;
                offset.Y = currentParams.Gravity;

                direction.Offset = offset;
                direction.Direction = entityInput.Axis == Vector3.Zero
                    ? Vector3.Zero
                    : Vector3.Normalize(entityInput.Axis);
            }
        }
    }
}