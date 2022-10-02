using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.Utils;
using Leopotam.EcsLite;
using Vector3 = UnityEngine.Vector3;

namespace Code.ECS.Client.Systems.Movement
{
    public class CharacterMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var locationFilter = world.Filter<CharacterMovement>().Inc<MovementDirection>().End();

            var characterMovement = world.GetPool<CharacterMovement>();
            var movementDirections = world.GetPool<MovementDirection>();

            foreach (var entity in locationFilter)
            {
                ref var character = ref characterMovement.Get(entity);
                ref var direction = ref movementDirections.Get(entity);

                Move(character, direction);
                Rotate(character, direction);
            }
        }

        private static void Move(CharacterMovement character, MovementDirection direction) => 
            character.Target.Move(direction.Offset.ToUnityVector3());

        private static void Rotate(CharacterMovement character, MovementDirection direction)
        {
            var directionVector = direction.Direction.ToUnityVector3();
            directionVector.y = 0;
            if (directionVector != Vector3.zero)
                character.Body.forward = directionVector;
        }
    }
}