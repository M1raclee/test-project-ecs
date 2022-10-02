using System.Collections.Generic;
using Code.ECS.Client.Components;
using Code.ECS.Shared.Components;
using Code.ECS.Shared.Tags;
using Code.Utils;
using Leopotam.EcsLite;

namespace Code.ECS.Client.Systems.Binding
{
    public class DoorsBindSystem : IEcsRunSystem
    {
        private Queue<DoorObject> _doorsObjects;

        public void SetupDoorsObject(DoorObject[] buttons) =>
            _doorsObjects = new Queue<DoorObject>(buttons);

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var doorsFilter = world.Filter<DoorTag>().Inc<Identifier>().Inc<Location>().End();
            
            var gameObjects = world.GetPool<GameObject>();
            var locations = world.GetPool<Location>();
            var doorIdentifiers = world.GetPool<Identifier>();
            var doorRestrictions = world.GetPool<DoorRestrictions>();

            foreach (var entity in doorsFilter)
            {
                if (gameObjects.Has(entity))
                    continue;
                
                ref var door = ref gameObjects.Add(entity);
                ref var restrictions = ref doorRestrictions.Add(entity);
                ref var identifier = ref doorIdentifiers.Get(entity);
                ref var location = ref locations.Get(entity);

                var objDoor = _doorsObjects.Dequeue();
                identifier.Guid = objDoor.Guid;
                door.Transform = objDoor.transform;
                location.Position = objDoor.transform.position.ToSystemVector3();
                restrictions.OpenedPosition = objDoor.OpenedPosition.ToSystemVector3();
                restrictions.ClosedPosition = objDoor.ClosedPosition.ToSystemVector3();
            }
        }
    }
}