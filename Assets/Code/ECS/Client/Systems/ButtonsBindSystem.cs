using System.Collections.Generic;
using Code.ECS.Client.Components;
using Code.ECS.Server.Tags;
using Code.ECS.Shared.Tags;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems
{
    public class ButtonsBindSystem : IEcsRunSystem
    {
        private Queue<ButtonObject> _buttonObjects;

        public void SetupButtonsObject(ButtonObject[] buttons) =>
            _buttonObjects = new Queue<ButtonObject>(buttons);
        
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var buttonsFilter = world.Filter<ButtonTag>().End();
            var buttons = world.GetPool<Button>();

            foreach (var entity in buttonsFilter)
            {
                if (buttons.Has(entity)) 
                    continue;
                
                ref var button = ref buttons.Add(entity);

                var objButton = _buttonObjects.Dequeue();
                button.Target = objButton;
                objButton.Entity = entity;
            }
        }
    }
}