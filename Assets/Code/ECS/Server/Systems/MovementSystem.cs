using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movableFilter = world.Filter<MovementDirection>().Inc<MovementInput>().Inc<MovementParams>().End();
            
            var movementVelocity = world.GetPool<MovementDirection>();
            var movementInput = world.GetPool<MovementInput>();
            var movementParams = world.GetPool<MovementParams>();

            foreach (var entity in movableFilter)
            {
                ref var direction = ref movementVelocity.Get(entity);
                ref var entityInput = ref movementInput.Get(entity);
                ref var currentParams = ref movementParams.Get(entity);

                var newDirection = entityInput.Axis * currentParams.Speed;
                newDirection.Y = currentParams.Gravity;
                
                direction.Offset = newDirection;
            }
        }
    }
}