using System;
using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class CharacterAnimationSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            
            var playerInputFilter = world.Filter<PlayerTag>().Inc<MovementAnimation>().Inc<MovementInput>().End();

            var inputs = world.GetPool<MovementInput>();
            var movementAnimation = world.GetPool<MovementAnimation>();

            foreach (var entity in playerInputFilter)
            {
                ref var animation = ref movementAnimation.Get(entity);
                ref var input = ref inputs.Get(entity);

                var isMoving = Math.Abs(input.Axis.X) > 0 || Math.Abs(input.Axis.Z) > 0;
                
                animation.Animator.SetBool(animation.IsMovingParam, isMoving);
            }
        }
    }
}