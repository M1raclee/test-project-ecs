using Code.ECS.Shared.Components;
using Leopotam.EcsLite;

namespace Code.ECS.Server.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movableFilter = world.Filter<Location>().Inc<MovementInput>().Inc<MovementMultiplier>().End();
            
            var location = world.GetPool<Location>();
            var movementInput = world.GetPool<MovementInput>();
            var movementMultiplier = world.GetPool<MovementMultiplier>();

            foreach (var entity in movableFilter)
            {
                ref var movableEntity = ref location.Get(entity);
                ref var entityInput = ref movementInput.Get(entity);
                ref var multiplier = ref movementMultiplier.Get(entity);

                movableEntity.Position += entityInput.Axis * multiplier.Multiplier;
            }
        }
    }
}