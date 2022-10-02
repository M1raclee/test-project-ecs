using System.Collections.Generic;
using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Utils;
using Leopotam.EcsLite;
using UnityEngine;
using GameObject = Code.ECS.Client.Components.GameObject;

namespace Code.ECS.Client.Systems.Binding
{
    public class ButtonsBindSystem : IEcsRunSystem
    {
        private Queue<ButtonObject> _buttonObjects;

        public void SetupButtonsObject(ButtonObject[] buttons) =>
            _buttonObjects = new Queue<ButtonObject>(buttons);

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var buttonsFilter = world.Filter<ButtonTag>().Inc<ButtonState>().Inc<Location>().Inc<PositionRestrictions>()
                .End();

            var gameObjects = world.GetPool<GameObject>();
            var buttonStates = world.GetPool<ButtonState>();
            var locations = world.GetPool<Location>();
            var positionRestrictions = world.GetPool<PositionRestrictions>();

            foreach (var entity in buttonsFilter)
            {
                if (gameObjects.Has(entity))
                    continue;

                ref var button = ref gameObjects.Add(entity);
                ref var state = ref buttonStates.Get(entity);
                ref var location = ref locations.Get(entity);
                ref var restrictions = ref positionRestrictions.Get(entity);

                var objButton = _buttonObjects.Dequeue();
                var buttonPos = objButton.transform.position;

                button.Object = objButton.gameObject;
                button.Transform = objButton.transform;
                state.TargetDoorGuid = objButton.TargetGuid;
                location.Position = buttonPos.ToSystemVector3();
                restrictions.MaxPosition = buttonPos.ToSystemVector3();
                restrictions.MinPosition = (buttonPos - new Vector3(0, objButton.PressingOffset, 0)).ToSystemVector3();

                objButton.Entity = entity;
            }
        }
    }
}