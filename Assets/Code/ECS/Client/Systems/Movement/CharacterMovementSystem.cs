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
            var locationFilter = world.Filter<CharacterMovement>().Inc<MovementResult>().End();

            var characterMovement = world.GetPool<CharacterMovement>();
            var movementResults = world.GetPool<MovementResult>();

            foreach (var entity in locationFilter)
            {
                ref var character = ref characterMovement.Get(entity);
                ref var result = ref movementResults.Get(entity);

                Move(character, result);
                Rotate(character, result);
            }
        }

        private static void Move(CharacterMovement character, MovementResult result) => 
            character.Target.Move(result.Offset.ToUnityVector3());

        private static void Rotate(CharacterMovement character, MovementResult result)
        {
            var directionVector = result.Direction.ToUnityVector3();
            directionVector.y = 0;
            if (directionVector != Vector3.zero)
                character.Body.forward = directionVector;
        }
    }
}