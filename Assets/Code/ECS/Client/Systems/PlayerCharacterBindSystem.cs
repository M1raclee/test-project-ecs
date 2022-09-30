using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
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

            foreach (var entity in playerFilter)
            {
                if (characterMovement.Has(entity)) 
                    continue;
                
                ref var character = ref characterMovement.Add(entity);
                character.Target = _playerObject.Character;
            }
        }
    }
}