using Code.ECS.Client.Components;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems.Binding
{
    public class PlayerCharacterBindSystem : IEcsRunSystem
    {
        private PlayerObject _playerObject;

        public void SetupPlayerObject(PlayerObject playerObject) =>
            _playerObject = playerObject;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var playerFilter = world.Filter<PlayerTag>().End();
            var characterMovement = world.GetPool<CharacterMovement>();
            var movementAnimation = world.GetPool<MovementAnimation>();
            var collisionDetector = world.GetPool<CollisionDetector>();

            foreach (var entity in playerFilter)
            {
                if (characterMovement.Has(entity)) 
                    continue;

                ref var animation = ref movementAnimation.Add(entity);
                ref var character = ref characterMovement.Add(entity);
                ref var colDetector = ref collisionDetector.Add(entity);

                character.Target = _playerObject.Character;
                character.Body = _playerObject.transform;
                
                animation.Animator = _playerObject.Animator;
                animation.IsMovingParamName = "IsWalking";
                
                colDetector.Detector = _playerObject.CollisionDetector;
            }
        }
    }
}