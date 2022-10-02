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

                Move(character, to: result.Offset.ToUnityVector3());
                Rotate(character, to: result.Direction.ToUnityVector3());
            }
        }

        private static void Move(CharacterMovement character, Vector3 to) => 
            character.Target.Move(to);

        private static void Rotate(CharacterMovement character, Vector3 to)
        {
            to.y = 0;
            
            if (to != Vector3.zero)
                character.Body.forward = to;
        }
    }
}