using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems
{
    public class VelocityMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movableFilter = world.Filter<MovementVelocity>().Inc<MovementInput>().Inc<MovementParams>().End();
            
            var movementVelocity = world.GetPool<MovementVelocity>();
            var movementInput = world.GetPool<MovementInput>();
            var movementParams = world.GetPool<MovementParams>();

            foreach (var entity in movableFilter)
            {
                ref var velocity = ref movementVelocity.Get(entity);
                ref var entityInput = ref movementInput.Get(entity);
                ref var currentParams = ref movementParams.Get(entity);

                var newVelocity = entityInput.Axis * currentParams.Speed;
                newVelocity.Y = currentParams.Gravity;
                
                velocity.Velocity = newVelocity;
            }
        }
    }
}