using System.Collections.Generic;
using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class GameplayButtonsBindSystem : IEcsRunSystem
    {
        private Queue<ButtonObject> _buttonObjects;

        public void SetupButtonsObject(ButtonObject[] buttons) =>
            _buttonObjects = new Queue<ButtonObject>(buttons);
        
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var buttonsFilter = world.Filter<GameplayButtonTag>().End();
            var gameplayButtons = world.GetPool<GameplayButton>();

            foreach (var entity in buttonsFilter)
            {
                if (gameplayButtons.Has(entity)) 
                    continue;
                
                ref var button = ref gameplayButtons.Add(entity);

                var objButton = _buttonObjects.Dequeue();
                button.Target = objButton;
                objButton.Entity = entity;
            }
        }
    }
}