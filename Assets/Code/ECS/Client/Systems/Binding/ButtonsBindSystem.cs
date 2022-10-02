using System.Collections.Generic;
using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
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
            var buttonsFilter = world.Filter<ButtonTag>().Inc<ButtonState>().End();
            
            var gameObjects = world.GetPool<GameObject>();
            var buttonStates = world.GetPool<ButtonState>();

            foreach (var entity in buttonsFilter)
            {
                if (gameObjects.Has(entity)) 
                    continue;
                
                ref var button = ref gameObjects.Add(entity);
                ref var state = ref buttonStates.Get(entity);

                var objButton = _buttonObjects.Dequeue();
                button.Object = objButton.gameObject;
                state.TargetDoorGuid = objButton.TargetGuid;

                objButton.Entity = entity;
            }
        }
    }
}