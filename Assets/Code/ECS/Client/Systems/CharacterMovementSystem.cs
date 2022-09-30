using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.Utils;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class CharacterMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var locationFilter = world.Filter<CharacterMovement>().Inc<MovementVelocity>().End();
            
            var characterMovement = world.GetPool<CharacterMovement>();
            var movementVelocity = world.GetPool<MovementVelocity>();

            foreach (var entity in locationFilter)
            {
                ref var character = ref characterMovement.Get(entity);
                ref var velocity = ref movementVelocity.Get(entity);
                
                character.Target.Move(velocity.Velocity.ToUnityVector3());
            }
        }
    }
}